using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace InheritanceDemo
{

    public class Shape
    {
        public Shape(Canvas canvas)
        {
            _canvas = canvas;
        }


        public void Draw()
        {
            double left = _canvas.ActualWidth * _rand.NextDouble();
            double top = _canvas.ActualHeight * _rand.NextDouble();
            _element.SetValue(Canvas.LeftProperty, left);
            _element.SetValue(Canvas.TopProperty, top);
            _canvas.Children.Add(_element);
        }

        protected UIElement _element;
        Canvas _canvas;

        static Random _rand = new Random();
        
    }
   public  class Square:Shape
    {

        public Square(Canvas canvas):base(canvas)
        {
            //_canvas = canvas;
            //_rect = new Rectangle();
            //_rect.Width = 10;
            //_rect.Height = 10;
            //_rect.Fill = new SolidColorBrush(Colors.Green);
            //_rect.Stroke = new SolidColorBrush(Colors.Black);

           
            Rectangle rect = new Rectangle();
            rect.Width = 10;
            rect.Height = 10;
            rect.Fill = new SolidColorBrush(Colors.Green);
            rect.Stroke = new SolidColorBrush(Colors.Black);
            _element = rect;
        }

        public double ComputeCircumference()
        {
            return 0.0;
        }

        //public void Draw()
        //{
        //    double left = _canvas.ActualWidth * _rand.NextDouble();
        //    double top = _canvas.ActualHeight * _rand.NextDouble();
        //    _rect.SetValue(Canvas.LeftProperty, left);
        //    _rect.SetValue(Canvas.TopProperty, top);
        //    _canvas.Children.Add(_rect);

        //}

        //Rectangle _rect;
        //Canvas _canvas;
        //static Random _rand = new Random();
    }

    public class Circle:Shape
    {
        public Circle(Canvas canvas):base(canvas)
        {
            //_canvas = canvas;
            //_ellipse = new Ellipse();
            //_ellipse.Width = 10;
            //_ellipse.Height = 10;
            //_ellipse.Fill = new SolidColorBrush(Colors.Green);
            //_ellipse.Stroke = new SolidColorBrush(Colors.Black);

            Ellipse ellipse = new Ellipse();
            ellipse.Width = 10;
            ellipse.Height = 10;
            ellipse.Fill = new SolidColorBrush(Colors.Green);
            ellipse.Stroke= new SolidColorBrush(Colors.Black);

            _element = ellipse;


        }



        //public void Draw()
        //{
        //    double left = _canvas.ActualWidth * _rand.NextDouble();
        //    double top = _canvas.ActualHeight * _rand.NextDouble();
        //    _ellipse.SetValue(Canvas.LeftProperty, left);
        //    _ellipse.SetValue(Canvas.TopProperty, top);
        //    _canvas.Children.Add(_ellipse);

        //}

        //Ellipse _ellipse;
        //Canvas _canvas;
        //static Random _rand = new Random();
    }
}
