using Mde.Oef.RPSGame.Domain;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace Mde.Oef.RPSGame.Converters
{

    public class HandToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Hand)
            {
                var hand = (Hand) value;
                switch (hand)
                {
                    case Hand.Rock:
                        return ImageSource.FromFile("rock.png");
                    case Hand.Paper:
                        return ImageSource.FromFile("paper.png");
                    case Hand.Scissors:
                        return ImageSource.FromFile("scissors.png");
                }
            }
            else
            {
                throw new ArgumentException($"{nameof(value)} must be of type Hand");
            }
            //default value is a rock image...
            return ImageSource.FromFile("rock.png"); ;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
