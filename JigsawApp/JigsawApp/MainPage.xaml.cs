using JigsawApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JigsawApp
{
    public partial class MainPage : ContentPage
    {

        public static Image tmpImage = new Image();
        public static Image tmpImage2 = new Image();
        public int tmpRow, tmpCol, tmpRow2, tmpCol2;

        private double pictureOneRot;

        public double PictureOneRot
        {
            get { return pictureOneRot; }
            set { pictureOneRot = value; OnPropertyChanged(); }
        }

        private double pictureTwoRot;

        public double PictureTwoRot
        {
            get { return pictureTwoRot; }
            set { pictureTwoRot = value; OnPropertyChanged(); }
        }

        private double pictureTreeRot;

        public double PictureTreeRot
        {
            get { return pictureTreeRot; }
            set { pictureTreeRot = value; OnPropertyChanged(); }
        }

        private double pictureFourRot;

        public double PictureFourRot
        {
            get { return pictureFourRot; }
            set { pictureFourRot = value; OnPropertyChanged(); }
        }

        public MainPage()
        {
            BindingContext = this;
            StartGame();
            InitializeComponent();
        }
       
        void OnTapGestureRecognizerTappedRotate(object sender, EventArgs args)
        {
            var imageSender = (Image)sender;

            
            if(imageSender.Rotation == 270)
            {
                imageSender.Rotation = 0;
            }
            else
            {
                imageSender.Rotation = imageSender.Rotation + 90;
            }

            if(imageSender.ClassId.ToString().Equals("Image1"))
            {
                PictureOneRot = imageSender.Rotation;
            }
            else if (imageSender.ClassId.ToString().Equals("Image2"))
            {
                PictureTwoRot = imageSender.Rotation;
            }
            else if (imageSender.ClassId.ToString().Equals("Image3"))
            {
                PictureTreeRot = imageSender.Rotation;
            }
            else if (imageSender.ClassId.ToString().Equals("Image4"))
            {
                PictureFourRot = imageSender.Rotation;
            }
        }

        void OnTapGestureRecognizerTappedMove(object sender, EventArgs args)
        {
            Image img = (Image)sender;

            for (int i = 0; i < grd.RowDefinitions.Count; i++)
            {
                for (int j = 0; j < grd.ColumnDefinitions.Count; j++)
                {
                    if (img.Id.Equals(FindByCell(grd, i, j).Id) && tmpImage.Source == null)
                    {
                        tmpImage.Source = FindByCell(grd, i, j).Source;
                        tmpCol = j;
                        tmpRow = i;
                    }
                    else if (img.Id.Equals(FindByCell(grd, i, j).Id) && tmpImage.Source != null)
                    {
                        tmpImage2.Source = FindByCell(grd, i, j).Source;
                        tmpCol2 = j;
                        tmpRow2 = i;
                    }
                }
            }

            if (tmpImage.Source != null && tmpImage2.Source != null)
            {
                FindByCell(grd, tmpRow, tmpCol).Source = tmpImage2.Source;
                FindByCell(grd, tmpRow2, tmpCol2).Source = tmpImage.Source;
                tmpImage.Source = null;
                tmpImage2.Source = null;

                CheckWinner();
            }
        }

        Image FindByCell(Grid g, int row, int col)
        {
            var childs = g.Children.Cast<Image>();
            return childs.Where(x => Grid.GetRow(x) == row && Grid.GetColumn(x) == col).FirstOrDefault();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            CheckWinner();
        }

        private void StartGame()
        {
            /*
             PictureOne.Rotation = RotationGenerator();
             PictureTwo.Rotation = RotationGenerator();
             PictureTree.Rotation = RotationGenerator();
             PictureFour.Rotation = RotationGenerator();
            */
           
            PictureOneRot = RotationGenerator();
            PictureTwoRot = RotationGenerator();
            PictureTreeRot = RotationGenerator();
            PictureFourRot = RotationGenerator();
        }


        private int RotationGenerator()
        {
            Random rnd = new Random();
            int[] rotationArray = new int[] { 0, 90, 180, 270 };
            int index = rnd.Next(0, rotationArray.Length);

            return rotationArray[index];
        }

        private void CheckWinner()
        {
            
          if(PictureOneRot == 0 && PictureTwoRot == 0 && PictureTreeRot == 0 && pictureFourRot == 0)
            {
                DisplayAlert("Winner", "Du er en sand vinder!", "Bekræft");
            }
        }
    }

        }