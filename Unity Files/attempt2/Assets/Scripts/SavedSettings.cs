public static class SavedSettings
{
    private static double startX, startY, startZ, points;
    private static double newX, newY, newZ;
    private static int runSpeed;
    private static bool gameMode;

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

    public static double NewX
    {
        get
        {
            return newX;
        }
        set
        {
            newX = value;
        }
    }

    public static double NewY
    {
        get
        {
            return newY;
        }
        set
        {
            newY = value;
        }
    }

    public static double NewZ
    {
        get
        {
            return newZ;
        }
        set
        {
            newZ = value;
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

    public static bool GameMode
    {
        get
        {
            return gameMode;
        }
        set
        {
            gameMode = value;
        }
    }
}