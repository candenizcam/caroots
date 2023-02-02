namespace Punity.tools
{
    public static class MathTools
    {
        /** Takes a field, row and col no and aspect (w/h) of single unit
         * returns width and height of the full grid, along with unit sizes of a single grid element
         */
        public static (float width, float height, float unitWidth, float unitHeight) FitGrid(float frameWidth, float frameHeight, int r, int c, float gridAspect=1f)
        {
            var normalHeight = (float)r;
            var normalWidth = c * gridAspect;

            var widthRate = frameWidth / normalWidth;
            var heightRate = frameHeight / normalHeight;

            if (widthRate > heightRate)
            {
                var unitHeight = heightRate;
                var unitWidth = heightRate * gridAspect;

                return (unitWidth * c, unitHeight * r, unitWidth, unitHeight);

            }
            else
            {
                var unitWidth = widthRate;
                var unitHeight = widthRate / gridAspect;

                return (unitWidth * c, unitHeight * r, unitWidth, unitHeight);
            }



        }
    }
}