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
        public int pictureOnePositionRow = 0;
        public int pictureOnePositionColumn = 0;
        public int pictureTwoPositionRow = 0;
        public int pictureTwoPositionColumn = 0;
        public Image imageSenderTemp;

        public ObservableCollection<Image> imageCollection;




        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new ViewModel();

            imageCollection = new ObservableCollection<Image>();


     
            

           
        }
        public class ViewModel
        {
            public ViewModel()
            {
                ImagePuz img1 = new ImagePuz { Id = 1, Path = "Zookie.jpg" };
                ImagePuz img2 = new ImagePuz { Id = 2, Path = "Zookie1.jpg" };
                ImagePuz img3 = new ImagePuz { Id = 3, Path = "Zookie2.jpg" };
                ImagePuz img4 = new ImagePuz { Id = 4, Path = "Zookie3.jpg" };
            }
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

            imageSenderTemp = (Image)sender;

            if (ImageCounterClick == 0)
            {
                pictureOnePositionRow = Grid.GetRow(imageSender);
                pictureOnePositionColumn = Grid.GetColumn(imageSender);

                imageSenderTemp = imageSender;

            }
            else if (ImageCounterClick == 1)
            {
                pictureTwoPositionRow = Grid.GetRow(imageSender);
                pictureTwoPositionColumn = Grid.GetColumn(imageSender);

                Grid.SetRow(imageSender, pictureOnePositionRow);
                Grid.SetColumn(imageSender, pictureOnePositionColumn);

                Grid.SetRow(imageSenderTemp, pictureTwoPositionRow);
                Grid.SetColumn(imageSenderTemp, pictureTwoPositionColumn);


                DisplayAlert("Alert", "You have been alerted", "OK");

            }

            ImageCounterClick++;

            if(ImageCounterClick == 2)
            {
                ImageCounterClick = 0;
            }
        }

        private void StartGame(object sender, EventArgs e)
        {
            PictureOne.Rotation = RotationGenerator();
            PictureTwo.Rotation = RotationGenerator();
            PictureTree.Rotation = RotationGenerator();
            PictureFour.Rotation = RotationGenerator();



        }

        private int RotationGenerator()
        {
            Random rnd = new Random();
            int[] rotationArray = new int[] { 0, 90, 180, 270 };
            int index = rnd.Next(0, rotationArray.Length);

            return rotationArray[index];
        }
    }

        }