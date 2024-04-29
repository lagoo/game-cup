namespace Domain.Entities
{
    public class Game
    {
        public Game(string identifier, string title, string console, decimal grade, int year, string imageUrl)
        {
            Identifier = identifier;
            Title = title;
            Console = console;
            Grade = grade;
            Year = year;
            ImageUrl = imageUrl;
        }

        public string Identifier { get; }
        public string Title { get; }
        public string Console { get; }
        public decimal Grade { get; }
        public int Year { get; }
        public string ImageUrl { get; }

        public static bool operator >(Game left, Game right)
        {
            if (left is null || right is null)
                return false;

            return left.Grade > right.Grade;
        }

        public static bool operator <(Game left, Game right)
        {
            if (left is null || right is null)
                return false;

            return left.Grade < right.Grade;
        }

        public static bool operator ==(Game left, Game right)
        {
            if (left is null || right is null)
                return false;

            return left.Grade == right.Grade;
        }

        public static bool operator !=(Game left, Game right)
        {
            if (left is null || right is null)
                return false;

            return left.Grade != right.Grade;
        }

        public override bool Equals(object obj)
        {
            if (obj is not Game item)
                return false;

            return this.Identifier.Equals(item.Identifier);
        }

        public override int GetHashCode()
        {
            return Identifier.GetHashCode();
        }

        public override string ToString()
        {
            return $"Title: {Title}, Grade: {Grade}, Year: {Year}";
        }
    }
}
