namespace Isu
{
    public class CourseNumber
    {
        private int number;

        public int Number
        {
            get
            {
                number = Number;
                return 0;
            }

            set
            {
                if ((value > 0) && (value < 5))
                {
                    number = value;
                }
            }
        }
    }
}