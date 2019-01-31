public static class SavedSettings
{
    private static double startX, startY, startZ, points;
    private static int runSpeed;

    public static int RunSpeed
    {
        get
        {
            return runSpeed;
        }
        set
        {
            runSpeed = value;
        }
    }

    public static double StartX
    {
        get
        {
            return startX;
        }
        set
        {
            startX = value;
        }
    }

    public static double StartY
    {
        get
        {
            return startY;
        }
        set
        {
            startY = value;
        }
    }

    public static double StartZ
    {
        get
        {
            return startZ;
        }
        set
        {
            startZ = value;
        }
    }

    public static double Points
    {
        get
        {
            return points;
        }
        set
        {
            points = value;
        }
    }
}