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

        public int ImageCounterClick = 0;
        public int pictureOneÍD = 0;
        public string pictureOnePath = "";
        public int pictureTwoÍD = 0;
        public string pictureTwoPath = "";

        private int pictureOneRot;

        public int PictureOneRot
        {
            get { return pictureOneRot; }
            set { pictureOneRot = value; OnPropertyChanged(); }
        }

        private int pictureTwoRot;

        public int PictureTwoRot
        {
            get { return pictureTwoRot; }
            set { pictureTwoRot = value; OnPropertyChanged(); }
        }

        private int pictureTreeRot;

        public int PictureTreeRot
        {
            get { return pictureTreeRot; }
            set { pictureTreeRot = value; OnPropertyChanged(); }
        }

        private int pictureFourRot;

        public int PictureFourRot
        {
            get { return pictureFourRot; }
            set { pictureFourRot = value; OnPropertyChanged(); }
        }



        private Image imageSenderTemp;

        public Image ImageSenderTemp
        {
            get { return imageSenderTemp; }
            set { imageSenderTemp = value; OnPropertyChanged(); }
        }

        private Image imageSenderTemp2;

        public Image ImageSenderTemp2
        {
            get { return imageSenderTemp2; }
            set { imageSenderTemp2 = value; OnPropertyChanged(); }
        }

        public string holderPictureOne = "";
        public string holderPictureTwo = "";


        private string image1;

        public string Image1
        {
            get { return image1; }
            set { image1 = value; OnPropertyChanged(); }
        }


        private string image2;

        public string Image2
        {
            get { return image2; }
            set { image2 = value; OnPropertyChanged(); }
        }

        private string image3;

        public string Image3
        {
            get { return image3; }
            set { image3 = value; OnPropertyChanged(); }
        }
        private string image4;

        public string Image4
        {
            get { return image4; }
            set { image4 = value; OnPropertyChanged(); }
        }


        ImagePuz img1 = new ImagePuz { Id = 1, Path = "Zookie1.jpg" };
        ImagePuz img2 = new ImagePuz { Id = 2, Path = "Zookie2.jpg" };
        ImagePuz img3 = new ImagePuz { Id = 3, Path = "Zookie3.jpg" };
        ImagePuz img4 = new ImagePuz { Id = 4, Path = "Zookie4.jpg" };

        public MainPage()
        {
            BindingContext = this;
            Image1 = img1.Path;
            Image2 = img2.Path;
            Image3 = img3.Path;
            Image4 = img4.Path;
            StartGame();
            CheckWinner();
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
        }

        void OnTapGestureRecognizerTappedMove(object sender, EventArgs args)
        {
    
            var imageSender = (Image)sender;

            

            if (ImageCounterClick == 0)
            {
               string path = imageSender.Source.ToString().Replace("File: ", "");

                imageSenderTemp = (Image)sender;

                if (path == img1.Path)
                    {
                        pictureOneÍD = img1.Id;
                        pictureOnePath = img1.Path;
                    }
                    else if (path == img2.Path)
                    {
                         pictureOneÍD = img2.Id;
                         pictureOnePath = img2.Path;
                    }
                    else if (path == img3.Path)
                    {
                        pictureOneÍD = img3.Id;
                        pictureOnePath = img3.Path;
                    }
                    else if (path == img4.Path)
                    {
                        pictureOneÍD = img4.Id;
                        pictureOnePath = img4.Path;
                    }

                holderPictureOne = imageSender.ClassId;

            }
            else if (ImageCounterClick == 1)
            {
                string path = imageSender.Source.ToString().Replace("File: ", "");

                if (path == img1.Path)
                {
                    pictureTwoÍD = img1.Id;
                    pictureTwoPath = img1.Path;
                }
                else if (path == img2.Path)
                {
                    pictureTwoÍD = img2.Id;
                    pictureTwoPath = img2.Path;
                }
                else if (path == img3.Path)
                {
                    pictureTwoÍD = img3.Id;
                    pictureTwoPath = img3.Path;
                }
                else if (path == img4.Path)
                {
                    pictureTwoÍD = img4.Id;
                    pictureTwoPath = img4.Path;
                }

                imageSenderTemp2 = imageSender;
                movePuzzle();



            }

            ImageCounterClick++;

            if(ImageCounterClick == 2)
            {
                ImageCounterClick = 0;
            }

        }

        private void movePuzzle()
        {

            string pathOne = imageSenderTemp.Source.ToString().Replace("File: ", "");
            string pathTwo = imageSenderTemp2.Source.ToString().Replace("File: ", "");


          //  DisplayAlert("Alert", ImageSenderTemp.ClassId.ToString() + " " + imageSenderTemp2.ClassId.ToString(), "OK");

            if (imageSenderTemp.ClassId == "Image1")
            {
                Image1 = pathTwo;
            }
            else if(imageSenderTemp.ClassId == "Image2")
            {
                Image2 = pathTwo;
            }
            else if (imageSenderTemp.ClassId == "Image3")
            {
                Image3 = pathTwo;
            }
            else if (imageSenderTemp.ClassId == "Image4")
            {
                Image4 = pathTwo;
            }

            if (imageSenderTemp2.ClassId == "Image1")
            {
                Image1 = pathOne;
            }
            else if (imageSenderTemp2.ClassId == "Image2")
            {
                Image2 = pathOne;
            }
            else if (imageSenderTemp2.ClassId == "Image3")
            {
                Image3 = pathOne;
            }
            else if (imageSenderTemp2.ClassId == "Image4")
            {
                Image4 = pathOne;
            }
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
          
        }
    }

        }