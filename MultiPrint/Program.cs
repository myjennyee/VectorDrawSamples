using System;
using System.Threading;
using VectorDraw.Generics;
using VectorDraw.Professional.Components;
using VectorDraw.Professional.vdObjects;

//Description
//This is a console sample that demonstrates a multi thread printing operation to multiple files.
//The default command line arguments are : C:\test\*.vdml pdf which means that all vdml files of the folder c:\Test will be printed into PDF format.

namespace MultiPrint
{

    class Program
    {
        static string[] SupportImportFormats = new string[] { "vdml", "vdcl" };
        static string[] SupportPrintFormats = new string[] { "jpg", "pdf" };

        public static bool IsImportFormat(string filename)
        {
            foreach (string item in SupportImportFormats)
            {
                if (filename.EndsWith("." + item, StringComparison.InvariantCultureIgnoreCase)) return true;
            }
            return false;
        }
        public static bool IsPrintExportFormat(string ExportFileName)
        {
            if (ExportFileName == "" ||
               ExportFileName.EndsWith(".", StringComparison.InvariantCultureIgnoreCase)) return true;
            foreach (string item in SupportPrintFormats)
            {
                if (ExportFileName.EndsWith("." + item, StringComparison.InvariantCultureIgnoreCase)) return true;
            }
            return false;
        }

        static void PrintUsage()
        {
            string str = "[sourcedir] [destination extension]\n" +
                           "sourcedir : directoryname\\*.*;or a single full pathname ; or directoryname\\*.ext1;*.ext2;.....\n" +
                           "destination extension : an extension example \".pdf\" or \"pdf\" or \".\" to print in default system printer....\n" +
                           "example: D:\\Trampa\\test\\*.vdml pdf   \n\t\t\twill export all vdml drawings to a pdf ,with same name and in the same directory.\n";
            Console.Write(str);
        }
        static void Pause()
        {
            Console.WriteLine("Press any key to continue");
            Console.Read();
        }

        static int OpenThreads = 0;
        static EventWaitHandle eventExit = new ManualResetEvent(false);
        [STAThread]
        static void Main(string[] args)
        {
            Console.BufferWidth = 180;
            if (args.Length == 0) { PrintUsage(); goto finish; }
            string ExportExtension = "";
            if (args.Length > 1)
            {
                ExportExtension = args[1].Trim(new char[] { ' ', '.' });
            }
            ExportExtension = string.Format(".{0}", ExportExtension);
            if (!IsPrintExportFormat(ExportExtension)) { PrintUsage(); goto finish; }
            string source = args[0].Trim();
            string folder = "";
            string[] extensions = null;
            int findMultiExtension = source.IndexOf('*');
            if (findMultiExtension >= 0)
            {
                extensions = source.Substring(findMultiExtension).Split(new char[] { '*' }, StringSplitOptions.RemoveEmptyEntries);
                folder = source.Substring(0, findMultiExtension);
            }
            else
            {
                if (System.IO.Path.HasExtension(source))
                {
                    extensions = new string[] { System.IO.Path.GetExtension(source).Replace("*", "") };
                    folder = System.IO.Path.GetDirectoryName(source);
                }
                else
                {
                    extensions = new string[] { "." };
                    folder = source;
                }
            }
            if (!System.IO.Directory.Exists(folder)) { PrintUsage(); goto finish; }
            string[] files = System.IO.Directory.GetFiles(folder, "*.*", System.IO.SearchOption.TopDirectoryOnly);
            vdArray<string> filenames = new vdArray<string>();
            foreach (string filename in files)
            {
                if (!IsImportFormat(filename)) continue;
                foreach (string ext in extensions)
                {
                    if (ext == "." || filename.EndsWith(ext, StringComparison.InvariantCultureIgnoreCase))
                    {
                        filenames.AddItem(filename);
                        break;
                    }
                }

            }
            if (filenames.Count > 0)
            {
                Console.Clear();
                OpenThreads = filenames.Count;
                for (int i = 0; i < filenames.Count; i++)
                    BeginNewPrintJob(filenames[i], ExportExtension, i);
                eventExit.WaitOne();
                Console.SetCursorPosition(0, filenames.Count);
            }
            else
            {
                Console.Write("0 Files Found\n");
            }
        finish:

            Pause();
        }



        static void BeginNewPrintJob(string filename, string ExportExtension, int jobid)
        {
            DocumentJob job = new DocumentJob(jobid);
            Thread thread = new Thread(new ParameterizedThreadStart(job.PrintFile));
            thread.Name = "PrintJob : " + filename;
            thread.SetApartmentState(ApartmentState.MTA);
            thread.Start(new object[] { filename, ExportExtension });
        }
        class DocumentJob
        {
            int lineNo = 0;
            public DocumentJob(int jobId)
            {
                lineNo = jobId;
            }
            public void PrintFile(object Params)
            {
                string fname = ((object[])Params)[0] as string;
                string ExportExtension = ((object[])Params)[1] as string;
                try
                {
                    PrintMessage(string.Format("{0,-40} ", System.IO.Path.GetFileName(fname)) + "Start");
                    vdDocumentComponent DocComponent = new vdDocumentComponent();
                    vdDocument document = DocComponent.Document;
                    document.FileName = fname;
                    document.OnPrompt += new vdDocument.PromptEventHandler(document_OnPrompt);
                    document.OnProgress += new VectorDraw.Professional.Utilities.ProgressEventHandler(document_OnProgress);
                    document.GenericError += new vdDocument.GenericErrorEventHandler(document_GenericError);

                    bool success = false;
                    string exportFileName = ExportExtension == "." ? "" : System.IO.Path.GetDirectoryName(fname) + @"\" + System.IO.Path.GetFileNameWithoutExtension(fname) + ExportExtension;

                    success = document.Open(fname);


                    if (success)
                    {
                        success = false;
                        if (IsPrintExportFormat(exportFileName))
                        {
                            vdPrint printer = document.Model.Printer;
                            printer.DocumentName = lineNo.ToString();
                            printer.PrinterName = exportFileName;
                            printer.Resolution = 300;
                            printer.OutInBlackWhite = true;
                            printer.paperSize = new System.Drawing.Rectangle(0, 0, 827, 1169);//A4
                            printer.LandScape = false;
                            printer.PrintExtents();
                            printer.PrintScaleToFit();
                            printer.CenterDrawingToPaper();
                            printer.PrintOut();
                            success = true;
                        }
                        else
                        {
                            success = document.SaveAs(exportFileName);
                        }
                    }

                    document.OnPrompt -= new vdDocument.PromptEventHandler(document_OnPrompt);
                    document.OnProgress -= new VectorDraw.Professional.Utilities.ProgressEventHandler(document_OnProgress);
                    document.GenericError -= new vdDocument.GenericErrorEventHandler(document_GenericError);

                    DocComponent.Dispose();
                    if (success) PrintMessage(string.Format("{0,-40} ", System.IO.Path.GetFileName(fname)) + "Finish");
                    else PrintMessage(string.Format("{0,-40} ", System.IO.Path.GetFileName(fname)) + "Error Exporting ");

                }
                catch { PrintMessage(string.Format("{0,-40} ", System.IO.Path.GetFileName(fname)) + "Error Exporting "); }
                finally
                {
                    OpenThreads--;
                    if (OpenThreads == 0) eventExit.Set();
                }

            }
            void PrintMessage(string message)
            {
                message = message.Replace("\r\n", "");
                message = message.Replace("\n", "");
                message += new string(' ', Console.BufferWidth - message.Length);
                lock (Console.Out)
                {
                    Console.SetCursorPosition(0, lineNo);
                    Console.Out.Write(message);
                }
            }
            void document_GenericError(object sender, string Membername, string errormessage)
            {
                vdDocument document = sender as vdDocument;
                PrintMessage(string.Format("{0,-40} ", System.IO.Path.GetFileName(document.FileName)) + Membername + errormessage);
            }
            void document_OnProgress(object sender, long percent, string jobDescription)
            {
                if (percent == 0) percent = 100;
                vdDocument document = sender as vdDocument;
                PrintMessage(string.Format("{0,-40} ", System.IO.Path.GetFileName(document.FileName)) + jobDescription + " : " + percent.ToString() + "%");
            }
            void document_OnPrompt(object sender, ref string promptstr)
            {
                if (promptstr == null) return;
                string str = promptstr;
                str = str.Trim();
                if (str == string.Empty) return;
                vdDocument document = sender as vdDocument;
                PrintMessage(string.Format("{0,-40} ", System.IO.Path.GetFileName(document.FileName)) + str);
            }
        }
    }
}
