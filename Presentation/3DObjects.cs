using System;
using System.Collections.Generic;
using System.Text;
using VectorDraw.Geometry;
using VectorDraw.Professional.vdObjects;
using VectorDraw.Professional.vdPrimaries;
using VectorDraw.Professional.vdFigures;
using VectorDraw.Professional.vdCollections;

namespace Presentation
{
    class _3DObjects
    {
        vdDocument mDocument = null;
        public _3DObjects(vdDocument doc)
        {
            mDocument = doc;
        }


        #region Table with chairs and glass
        /// <summary>
        /// Creates and returns a filled rect with thickness(3D box with the passed parameters).
        /// </summary>
        /// <param name="insertion">Insertion point of the object.</param>
        /// <param name="width">Width of the object.</param>
        /// <param name="length">Length of the object.</param>
        /// <param name="height">Height of the object.</param>
        /// <param name="isfilled">A boolean value representing if the object will be filled</param>
        /// <returns>The created object.</returns>
        private vdFigure CreateRect(gPoint insertion, double width, double length, double height, bool isfilled)
        {
            vdRect fig = new vdRect();
            fig.SetUnRegisterDocument(mDocument);
            fig.setDocumentDefaults();
            fig.InsertionPoint = insertion;
            fig.Width = width;
            fig.Height = length;
            fig.Thickness = height;
            if (isfilled) fig.HatchProperties = new vdHatchProperties(VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid);
            return fig;
        }
        /// <summary>
        /// Using the above method we create a table(4 legs and a top).
        /// </summary>
        /// <param name="width">Width of the table.</param>
        /// <param name="length">Length of the table.</param>
        /// <param name="height">Height of the table.</param>
        /// <returns>A selection containing all created objects.</returns>
        private vdSelection CreateTable(double width, double length, double height)
        {
            vdSelection ret = new vdSelection();
            ret.AddItem(CreateRect(new gPoint(), 0.05, 0.05, height - 0.05, false), false, vdSelection.AddItemCheck.Nochecking);
            ret.AddItem(CreateRect(new gPoint(length - 0.05, 0, 0), 0.05, 0.05, height - 0.05, false), false, vdSelection.AddItemCheck.Nochecking);
            ret.AddItem(CreateRect(new gPoint(length - 0.05, width - 0.05, 0), 0.05, 0.05, height - 0.05, false), false, vdSelection.AddItemCheck.Nochecking);
            ret.AddItem(CreateRect(new gPoint(0.0, width - 0.05, 0), 0.05, 0.05, height - 0.05, false), false, vdSelection.AddItemCheck.Nochecking);
            ret.AddItem(CreateRect(new gPoint(0, 0, height - 0.05), length, width, 0.05, true), false, vdSelection.AddItemCheck.Nochecking);
            return ret;
        }
        /// <summary>
        /// Using the CreateRect method we create a chair.
        /// </summary>
        /// <returns>A selection with the created objects.</returns>
        private vdSelection CreateChair()
        {
            vdSelection ret = new vdSelection();
            ret.AddRange(CreateTable(0.4, 0.4, 0.4), vdSelection.AddItemCheck.Nochecking);
            ret.AddItem(CreateRect(new gPoint(0, 0.0, 0.4), 0.4, 0.05, 0.5, true), false, vdSelection.AddItemCheck.Nochecking);
            return ret;
        }
        /// <summary>
        /// This method uses the Generate3dPathSection method in order to create a glass of water...
        /// </summary>
        /// <param name="room">The selection where the object is going to be added.</param>
        private void CreateGlassOfWater(vdSelection furniture)
        {
            //We will use a circle as path2 and a line as section which line is going to go round the circle and create thje polyface needed.
            vdCircle ci = new vdCircle();
            ci.Radius = 0.03;
            vdLine line = new vdLine(new gPoint(), new gPoint(0, 0, 0.12));
            vdPolyface pface = new vdPolyface();
            pface.SetUnRegisterDocument(mDocument);
            pface.setDocumentDefaults();
            pface.Generate3dPathSection(line, ci, new gPoint(0, 0.0, 0.0), 0, 1.1);

            //Position the glass on top of the table.
            Matrix matt = new Matrix();
            matt.TranslateMatrix(0.6, 0.4, 0.71);
            pface.Transformby(matt);
            furniture.AddItem(pface, false, vdSelection.AddItemCheck.Nochecking);

            //we add also the circle filled as bottom of the glass.
            vdCircle cibottom = new vdCircle();
            cibottom.SetUnRegisterDocument(mDocument);
            cibottom.setDocumentDefaults();
            cibottom.Radius = 0.03;
            cibottom.HatchProperties = new vdHatchProperties(VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid);
            cibottom.Transformby(matt);
            furniture.AddItem(cibottom, false, vdSelection.AddItemCheck.Nochecking);

            ci.Radius = 0.005;
            vdPolyline pline = new vdPolyline();
            pline.VertexList.Add(new gPoint());
            pline.VertexList.Add(new gPoint(0.025, 0.025, 0.2));
            pface = new vdPolyface();
            pface.SetUnRegisterDocument(mDocument);
            pface.setDocumentDefaults();
            pface.Generate3dPathSection(pline, ci, new gPoint(0, 0.0, 0.0), 0, 1);
            pface.Transformby(matt);
            furniture.AddItem(pface, false, vdSelection.AddItemCheck.Nochecking);
        }
        /// <summary>
        /// Creates a table and 2 chairs to the passed insertion point.
        /// </summary>
        /// <param name="Insertion">Insertion point of the objects.</param>
        public void AddTableWchairsAndGlass(gPoint Insertion)
        {
            vdSelection furniture = new vdSelection();
            SetActiveLayer("Table", 38, "wood", 2.0, 2.0, false, (byte)255);
            furniture.AddRange(CreateTable(0.8, 1.6, 0.7), vdSelection.AddItemCheck.Nochecking);

            Matrix mat = new Matrix();
            mat.TranslateMatrix(0.6, -0.4, 0);
            vdSelection chair = CreateChair();
            chair.Transformby(mat);
            furniture.AddRange(chair, vdSelection.AddItemCheck.Nochecking);

            mat = new Matrix();
            mat.RotateZMatrix(Globals.DegreesToRadians(180.0));
            mat.TranslateMatrix(1.0, 1.2, 0);
            chair = CreateChair();
            chair.Transformby(mat);
            furniture.AddRange(chair, vdSelection.AddItemCheck.Nochecking);

            SetActiveLayer("GlassOfWater", 4, null, 0.0, 0.0, false, (byte)150);
            CreateGlassOfWater(furniture);

            mat = new Matrix();
            mat.TranslateMatrix(Insertion);
            furniture.Transformby(mat);
            foreach (vdFigure var in furniture)
            {
                mDocument.ActiveLayOut.Entities.AddItem(var);
            }
        }
        #endregion

        #region ROOM
        /// <summary>
        /// Creates and adds a polyline with thickness to the passed selection. This gives the impression of a room
        /// </summary>
        /// <param name="room">The selection where the created walls are going to be added.</param>
        /// <remarks > The polyline has it's bottom left point 0,0.</remarks>
        private void CreateWalls(vdSelection room)
        {
            //Create the polyline.(create left rigth and behind walls)
            vdPolyline poly = new vdPolyline();
            poly.SetUnRegisterDocument(mDocument);
            poly.setDocumentDefaults();
            poly.VertexList.Add(new gPoint(1.5, 0.0));
            poly.VertexList.Add(new gPoint(0.0, 0.0));
            poly.VertexList.Add(new gPoint(0.0, 4.0));
            poly.VertexList.Add(new gPoint(6.0, 4.0));
            poly.VertexList.Add(new gPoint(6.0, 0.0));
            poly.VertexList.Add(new gPoint(5.5, 0.0));
            poly.VertexList.Add(new gPoint(5.5, 0.2));
            poly.VertexList.Add(new gPoint(5.8, 0.2));
            poly.VertexList.Add(new gPoint(5.8, 3.8));
            poly.VertexList.Add(new gPoint(0.2, 3.8));
            poly.VertexList.Add(new gPoint(0.2, 0.2));
            poly.VertexList.Add(new gPoint(1.5, 0.2));
            //We give solid fillmode to the polyline so when we apply the thickness
            //the top and the bottom of the 3d object will be filled.
            poly.HatchProperties = new vdHatchProperties(VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid);
            poly.Flag = VectorDraw.Professional.Constants.VdConstPlineFlag.PlFlagCLOSE;
            poly.Thickness = 3.0;
            poly.Update();
            //Add the created wall to the room's selection set.
            room.AddItem(poly, false, vdSelection.AddItemCheck.Nochecking);

            //We create separatelly the front(in peaces) wall in order to make the window.
            //First we create the part between the door and the window.
            poly = new vdPolyline();
            poly.SetUnRegisterDocument(mDocument);
            poly.setDocumentDefaults();
            poly.VertexList.Add(new gPoint(3.0, 0.0));
            poly.VertexList.Add(new gPoint(3.0, 0.2));
            poly.VertexList.Add(new gPoint(4.0, 0.2));
            poly.VertexList.Add(new gPoint(4.0, 0.0));
            
            poly.HatchProperties = new vdHatchProperties(VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid);
            poly.Flag = VectorDraw.Professional.Constants.VdConstPlineFlag.PlFlagCLOSE;
            poly.Thickness = 3.0;
            poly.Update();
            //Add the created wall to the room's selection set.
            room.AddItem(poly, false, vdSelection.AddItemCheck.Nochecking);

            //And then we create the top and bottom parts of the window.
            poly = new vdPolyline();
            poly.SetUnRegisterDocument(mDocument);
            poly.setDocumentDefaults();
            poly.VertexList.Add(new gPoint(1.5, 0.0));
            poly.VertexList.Add(new gPoint(1.5, 0.2));
            poly.VertexList.Add(new gPoint(3.0, 0.2));
            poly.VertexList.Add(new gPoint(3.0, 0.0));
            
            poly.HatchProperties = new vdHatchProperties(VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid);
            poly.Flag = VectorDraw.Professional.Constants.VdConstPlineFlag.PlFlagCLOSE;
            poly.Thickness = 1.3;
            poly.Update();
            //Add the created wall to the room's selection set.
            room.AddItem(poly, false, vdSelection.AddItemCheck.Nochecking);

            //And the top where using a matrix we position it where it should go.
            poly = new vdPolyline();
            poly.SetUnRegisterDocument(mDocument);
            poly.setDocumentDefaults();
            poly.VertexList.Add(new gPoint(1.5, 0.0));
            poly.VertexList.Add(new gPoint(1.5, 0.2));
            poly.VertexList.Add(new gPoint(3.0, 0.2));
            poly.VertexList.Add(new gPoint(3.0, 0.0));
            
            
            poly.HatchProperties = new vdHatchProperties(VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid);
            poly.Flag = VectorDraw.Professional.Constants.VdConstPlineFlag.PlFlagCLOSE;
            poly.Thickness = 1.1;

            Matrix matt = new Matrix();
            matt.TranslateMatrix(0.0, 0.0, 1.9);
            poly.Transformby(matt);
            poly.Update();
            //Add the created wall to the room's selection set.
            room.AddItem(poly, false, vdSelection.AddItemCheck.Nochecking);
        }
        /// <summary>
        /// Create a solid rect which we will make transparent to give the impression of glass.
        /// </summary>
        /// <param name="room">The selection where the glass is going to be added.</param>
        private void CreateWindow(vdSelection room)
        {
            //We will CreateWindow a transparent window.
            vdPolyline poly = new vdPolyline();
            poly.SetUnRegisterDocument(mDocument);
            poly.setDocumentDefaults();
            poly.VertexList.Add(new gPoint(1.5, 0.0));
            poly.VertexList.Add(new gPoint(3.0, 0.0));
            poly.HatchProperties = new vdHatchProperties(VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid);
            poly.Flag = VectorDraw.Professional.Constants.VdConstPlineFlag.PlFlagCLOSE;
            poly.Thickness = 0.6;

            Matrix matt = new Matrix();
            matt.TranslateMatrix(0.0, 0.1, 1.3);
            poly.Transformby(matt);
            poly.Update();
            //Add the created wall to the room's selection set.
            room.AddItem(poly, false, vdSelection.AddItemCheck.Nochecking);
        }
        /// <summary>
        /// Creates the bottom of the room using a filled solid polyline with the activeMaterial set by SetActiveLayer
        /// </summary>
        /// <param name="room"></param>
        private void CreateFloor(vdSelection room)
        {
            //We will use the same polyline(initialpoints without the rest points that give the wall the 0.2 width.)
            //but with fillmode solid without thickness.
            vdPolyline poly = new vdPolyline();
            poly.SetUnRegisterDocument(mDocument);
            poly.setDocumentDefaults();
            poly.VertexList.Add(new gPoint(6.0, 0.0,-0.001));
            poly.VertexList.Add(new gPoint(0.0, 0.0, -0.001));
            poly.VertexList.Add(new gPoint(0.0, 4.0, -0.001));
            poly.VertexList.Add(new gPoint(6.0, 4.0, -0.001));
            poly.HatchProperties = new vdHatchProperties(VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid);
            poly.Update();

            //Add the created floor polyline to the selection.
            room.AddItem(poly, false, vdSelection.AddItemCheck.Nochecking);
        }
        /// <summary>
        /// Using the Generate3dPathSection method we create the roof
        /// </summary>
        /// <param name="room">The selection where the objects are going to be added.</param>
        private void CreateRoof(vdSelection room)
        {
            vdPolyline triangle = new vdPolyline();
            triangle.SetUnRegisterDocument(mDocument);
            triangle.setDocumentDefaults();
            triangle.VertexList.Add(new gPoint(0.0, 0.0,0.0));
            triangle.VertexList.Add(new gPoint(0.0, 2.0,1.5));
            triangle.VertexList.Add(new gPoint(0.0, 4.0,0.0));
            triangle.ExtrusionVector = new Vector(1.0, 0.0, 0.0);
            triangle.Update();

            double h = Math.Pow(triangle.VertexList[0].Distance3D(triangle.VertexList[1]) , 2.0) - Math.Pow((4.0 / 2.0), 2.0) ;
            h = Math.Sqrt(h)+ 3.0;
            vdLine line = new vdLine(new gPoint(0.0, 2.0, h), new gPoint(6.0, 2.0, h));

            vdPolyface roof = new vdPolyface();
            roof.SetUnRegisterDocument(mDocument);
            roof.setDocumentDefaults();
            roof.Generate3dPathSection(line, triangle, new gPoint(0.0, 2.0, 1.5), 0, 1.0);
            
            room.AddItem(roof, false, vdSelection.AddItemCheck.Nochecking);

            triangle.HatchProperties = new vdHatchProperties(VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid);
            room.AddItem(triangle, false, vdSelection.AddItemCheck.Nochecking);

            vdPolyline triangleLeft = new vdPolyline();
            triangleLeft.SetUnRegisterDocument(mDocument);
            triangleLeft.setDocumentDefaults();
            triangleLeft.VertexList.AddRange(triangle.VertexList);
            Matrix matt = new Matrix();
            matt.TranslateMatrix (new gPoint(0.0,0.0,3.0));
            triangleLeft.Transformby(matt);
            triangleLeft.VertexList.Reverse();
            triangleLeft.HatchProperties = new vdHatchProperties(VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid);
            room.AddItem(triangleLeft,false, vdSelection.AddItemCheck.Nochecking);

            vdPolyline triangleRight = new vdPolyline();
            triangleRight.SetUnRegisterDocument(mDocument);
            triangleRight.setDocumentDefaults();
            triangleRight.VertexList.AddRange(triangle.VertexList);
            matt = new Matrix();
            matt.TranslateMatrix(new gPoint(6.0, 0.0, 3.0));
            triangleRight.Transformby(matt);
            triangleRight.HatchProperties = new vdHatchProperties(VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid);
            room.AddItem(triangleRight, false, vdSelection.AddItemCheck.Nochecking);


        }
        /// <summary>
        /// Adds the Room to the specified insertion point.
        /// </summary>
        /// <param name="insertion"></param>
        public void AddRoom(gPoint insertion)
        {
            vdSelection Room = new vdSelection();

            SetActiveLayer("WALL", 30, "bricks", 0.4, 0.4, false, (byte)255);
            CreateWalls(Room);

            SetActiveLayer("Window", 254, null, 1.0, 1.0, false, (byte)50);
            CreateWindow(Room);

            SetActiveLayer("Bottom", 31, "marble", 0.8, 0.8, false, (byte)255);
            CreateFloor(Room);

            SetActiveLayer("ROOF", 5, "roof", 0.8, 0.8, false, (byte)255);
            CreateRoof(Room);

            //We create a matrix in order to transform the selection and place it in the insertion point.
            Matrix matt = new Matrix();
            matt.Transform (insertion);
            Room.Transformby(matt);
            foreach (vdFigure var in Room)
	        {
                mDocument.ActiveLayOut.Entities.AddItem(var); 
	        }
        }
        #endregion

        #region Painting
        /// <summary>
        /// Creates and adds a polyline with thickness to the passed selection.
        /// </summary>
        /// <param name="Painting">The selection where the created frame is going to be added.</param>
        /// <param name="width">The width of the painting.</param>
        /// <param name="height">The height of the painting.</param>
        /// <param name="offset">The offset of the painting.</param>
        /// <remarks > The polyline has it's bottom left point 0,0.</remarks>
        private void CreateFrame(vdSelection Painting,double width,double height ,double offset)
        {
            //We will use the same tecknique as with the walls to create a 3d object with measures 0.4,0.3,0.05 as width,height,offset
            //with fillmode solid and thickness 0.03.
            vdPolyline poly = new vdPolyline();
            poly.SetUnRegisterDocument(mDocument);
            poly.setDocumentDefaults();
            poly.VertexList.Add(new gPoint(0.0, 0.0));
            poly.VertexList.Add(new gPoint(width, 0.0));
            poly.VertexList.Add(new gPoint(width, height));
            poly.VertexList.Add(new gPoint(0.0, height));
            poly.VertexList.Add(new gPoint(0.0, 0.0));
            poly.VertexList.Add(new gPoint(offset, offset));
            poly.VertexList.Add(new gPoint(offset, height - offset));
            poly.VertexList.Add(new gPoint(width - offset , height - offset));
            poly.VertexList.Add(new gPoint(width - offset, offset));
            poly.VertexList.Add(new gPoint(offset, offset));
            poly.HatchProperties = new vdHatchProperties(VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid);
            poly.Flag = VectorDraw.Professional.Constants.VdConstPlineFlag.PlFlagCLOSE;
            poly.Thickness = 0.03;
            poly.Update();
            //Add the created frame to the paintin's selection.
            Painting.AddItem(poly, false, vdSelection.AddItemCheck.Nochecking);
        }
        /// <summary>
        /// Creates and adds a filled polyline to the passed selection.
        /// </summary>
        /// <param name="Painting">The painting's selection where the created polyline will be added.</param>
        /// <param name="width">The width of the painting.</param>
        /// <param name="height">The height of the painting.</param>
        /// <param name="offset">The offset of the painting.</param>
        private void Createpainting(vdSelection Painting, double width, double height, double offset)
        {
            vdLine line = new vdLine();
            line.SetUnRegisterDocument(mDocument);
            line.setDocumentDefaults();
            //We will use only the internal points of the frame in order to fit our painting.
            line.StartPoint = new gPoint(offset, offset);
            line.EndPoint = new gPoint(width,offset);
            line.Thickness = height - 2*offset;
            line.ExtrusionVector = new Vector(0, 1, 0);
            line.Update();

            //We add the created painting to the painting's selection set.
            Painting.AddItem(line, false, vdSelection.AddItemCheck.Nochecking);
        }
        /// <summary>
        /// Using the above methods creates a painting.
        /// </summary>
        /// <param name="Insertion">The insertion point of the painting.</param>
        /// <param name="rotx">X rotation of the painting.</param>
        /// <param name="roty">Y rotation of the painting.</param>
        /// <param name="rotz">Z rotation of the painting.</param>
        public void AddPainting(gPoint Insertion, double rotx, double roty,double rotz)
        {
            //We create a Painting selection set where we will add the frame and the painting.
            vdSelection Painting = new vdSelection();
            SetActiveLayer("Frame", 39, "frame", 5.0, 5.0, false, (byte)255);
            CreateFrame (Painting,1.5,1.0,0.05);

            //We pass the last parameter true in order to be calculated to fit 1 time to our painting width and height.
            //We provide to the method the width and height of the painting(0.4,0.3).
            SetActiveLayer("Painting", 1, "painting", 1.5, 1.0, true, (byte)255);
            Createpainting(Painting, 1.5, 1.0, 0.05);


            //We create a matrix in order to transform the selection and place it in the insertion point.
            //We also apply the given rotations.
            Matrix matt = new Matrix();
            matt.RotateXMatrix(rotx);
            matt.RotateYMatrix(roty);
            matt.RotateZMatrix(rotz);
            matt.TranslateMatrix(Insertion);
            Painting.Transformby(matt);
            //Add it to our scene.
            foreach (vdFigure var in Painting)
            {
                mDocument.ActiveLayOut.Entities.AddItem(var);
            }
        }
        #endregion

        #region Light
        /// <summary>
        /// Creates a Light and adds it to the furniture selection.
        /// </summary>
        /// <param name="furniture">The selection where the objects are going to be added.</param>
        private void CreateLightObject(vdSelection furniture)
        {
            //Create the base of the light
            vdCircle Lightbase = new vdCircle();
            Lightbase.SetUnRegisterDocument(mDocument);
            Lightbase.setDocumentDefaults();
            Lightbase.Radius = 0.3;
            Lightbase.HatchProperties = new vdHatchProperties(VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid);
            furniture.AddItem(Lightbase,false, vdSelection.AddItemCheck.Nochecking);

            //Create the pole using the CreateRect method.
            furniture.AddItem(CreateRect(new gPoint(-0.025,-0.025), 0.05, 0.05, 1.5, true), false, vdSelection.AddItemCheck.Nochecking);

            //Create the sphere using the CreateSphere of the vdPolyface object.
            vdPolyface sphere = new vdPolyface();
            sphere.SetUnRegisterDocument(mDocument);
            sphere.setDocumentDefaults();
            sphere.CreateSphere(new gPoint(0.0, 0.0, 1.5), 0.4, 20, 20);
            
            furniture.AddItem (sphere,false, vdSelection.AddItemCheck.Nochecking);
        }
        /// <summary>
        /// Using the above method creates a light(furniture) and places it to the insertion point.
        /// </summary>
        /// <param name="Insertion"></param>
        public void AddLight(gPoint Insertion)
        {
            vdSelection furniture = new vdSelection();
            SetActiveLayer("Light", 0, null, 1.0, 1.0, false, (byte)128);
            CreateLightObject(furniture);

            //We create a matrix in order to transform the selection and place it in the insertion point.
            Matrix matt = new Matrix();
            matt.TranslateMatrix(Insertion);
            furniture.Transformby(matt);
            //Add it to our scene.
            foreach (vdFigure var in furniture)
            {
                mDocument.ActiveLayOut.Entities.AddItem(var);
            }
        }
        #endregion

        #region Exterior Objects
        /// <summary>
        /// Creates a rect filled and adds it to the passed selection.
        /// </summary>
        /// <param name="Exterior">The selection to add the created object.</param>
        /// <param name="width">The width of the rect</param>
        /// <param name="height">The height of the rect.</param>
        private void CreateGrass(vdSelection Exterior,double width,double height)
        {
            vdRect rect = new vdRect();
            rect.SetUnRegisterDocument(mDocument);
            rect.setDocumentDefaults();
            rect.Width = width;
            rect.Height = height;
            rect.HatchProperties = new vdHatchProperties(VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid);
            Exterior.AddItem(rect, false, vdSelection.AddItemCheck.Nochecking);
        }
        /// <summary>
        /// Creates a rect filled and adds it to the passed selection and also translates it to the passed point..
        /// </summary>
        /// <param name="Exterior">The selection to add the created object.</param>
        /// <param name="Insertion">The point to place the object.</param>
        /// <param name="width">The width of the rect</param>
        /// <param name="height">The height of the rect.</param>
        private void CreatePool(vdSelection Exterior, gPoint Insertion, double width, double height)
        {
            vdRect rect = new vdRect();
            rect.SetUnRegisterDocument(mDocument);
            rect.setDocumentDefaults();
            rect.Width = width;
            rect.Height = height;
            rect.InsertionPoint = Insertion;
            rect.HatchProperties = new vdHatchProperties(VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid);
            Exterior.AddItem(rect, false, vdSelection.AddItemCheck.Nochecking);
        }
        /// <summary>
        /// Creates the grass and the pool objects of the exterior of our scene.
        /// </summary>
        /// <param name="Insertion">Insertion point to place the objects.</param>
        public void AddExterior(gPoint Insertion)
        {
            vdSelection exterior = new vdSelection();
            SetActiveLayer("Grass", 2, "grass", 0.8, 0.8, false, (byte)255);
            CreateGrass(exterior,16.0,14.0);

            SetActiveLayer("Pool", 4, "water", 4.0, 3.0, true, (byte)255);
            CreatePool(exterior,new gPoint (6.0,3.0,0.001),4.0,3.0);

            //We create a matrix in order to transform the selection and place it in the insertion point.
            Matrix matt = new Matrix();
            matt.TranslateMatrix(Insertion);
            exterior.Transformby(matt);
            //Add it to our scene.
            foreach (vdFigure var in exterior)
            {
                mDocument.ActiveLayOut.Entities.AddItem(var);
            }
        }
        #endregion

        /// <summary>
        /// Creates a layer with the passed parameters.
        /// </summary>
        /// <param name="name">The name of the layer.</param>
        /// <param name="colorIndex">The color index of the layer's color.</param>
        /// <param name="MaterialPath">The path2 filename of the image to be used as material.</param>
        /// <param name="MaterialXScale">X scale or width used to calculate the scale the material for the painting.</param>
        /// <param name="MaterialYScale">Y scale or height used to calculate the scale the material for the painting.</param>
        /// <param name="Fit1Time">A boolean representing if the above parameters provide scales or width/height.</param>
        public void SetActiveLayer(string name, short  colorIndex, string MaterialPath, double MaterialXScale , double MaterialYScale,bool Fit1Time,byte transparency)
        {
            vdLayer lay = mDocument.Layers.Add(name);
            lay.PenColor.ColorIndex = colorIndex;
            if (MaterialPath != null)
            {
                vdImageDef def = mDocument.Images.FindName(MaterialPath);
                if (def == null)
                {
                    def = new vdImageDef();
                    def.Name =MaterialPath;
                    //def.FileName = @"C:\vdraw6\Examples\Presentation\Presentation\Materials\" + MaterialPath + ".jpg";
                    
                    System.IO.MemoryStream stream = new System.IO.MemoryStream();
                    switch (MaterialPath)
                    {
                        case "bricks": Presentation.Properties.Resources.bricks.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg); break;
                        case "floor": Presentation.Properties.Resources.floor.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg); break;
                        case "frame": Presentation.Properties.Resources.frame.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg); break;
                        case "grass": Presentation.Properties.Resources.grass.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg); break;
                        case "marble": Presentation.Properties.Resources.marble.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg); break;
                        case "painting": Presentation.Properties.Resources.Painting.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg); break;
                        case "water": Presentation.Properties.Resources.water.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg); break;
                        case "wood": Presentation.Properties.Resources.wood.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg); break;
                        case "roof": Presentation.Properties.Resources.Roof.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg); break;
                    }
                    byte[] bytes = stream.ToArray();
                    stream.Close();
                    VectorDraw.Geometry.ByteArray barray = new VectorDraw.Geometry.ByteArray(bytes);
                    def.InternalSetBytes(barray);
                    def.Update();                    
                    mDocument.Images.AddItem(def);
                }
                mDocument.Palette[colorIndex].MaterialImage = def;
                Matrix matt = new Matrix();
                if (!Fit1Time)
                    matt.ScaleMatrix(MaterialXScale, MaterialYScale, 1.0);
                else
                {
                    //Fit the image 1 time to the passed width and height.
                    matt.ScaleMatrix( 1/ MaterialXScale , 1/ MaterialYScale , 1.0);
                }
                mDocument.Palette[colorIndex].MaterialMatrix = matt;
            }
            if (transparency != (byte)255)
            {
                mDocument.Palette[colorIndex].ColorFlag = vdColor.ColorType.ByColor;
                mDocument.Palette[colorIndex].FromRGB(mDocument.Palette[colorIndex].Red, mDocument.Palette[colorIndex].Green, mDocument.Palette[colorIndex].Blue);
                mDocument.Palette[colorIndex].AlphaBlending = transparency;
            }
            mDocument.ActiveLayer = lay;
        }

    }
}
