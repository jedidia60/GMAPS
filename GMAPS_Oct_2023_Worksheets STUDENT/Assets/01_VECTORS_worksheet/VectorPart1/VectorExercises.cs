using UnityEngine;

public class VectorExercises : MonoBehaviour
{
    [SerializeField] LineFactory lineFactory;
    [SerializeField] bool Q2a, Q2b, Q2c, Q2d, Q2e;
    [SerializeField] bool Q3a, Q3b, Q3c, projection;

    private Line drawnLine;

    private Vector2 startPt;
    private Vector2 endPt;

    public float GameWidth, GameHeight;
    private float minX, minY, maxX, maxY;

    private void Start()
    {
        // Call this function first so the variables would be updated before it is used
        CalculateGameDimensions();

        if (Q2a)
            Question2a();
        if (Q2b)
            Question2b(5);
        if (Q2c)
            Question2c(5);
        if (Q2d)
            Question2d();
        if (Q2e)
            Question2e(20);
        if (Q3a)
            Question3a();
        if (Q3b)
            Question3b();
        if (Q3c)
            Question3c();
        if (projection)
            Projection();
    }

    // Called at the start to ensure the dimensions is calculated before it's used
    public void CalculateGameDimensions()
    {
        GameHeight = Camera.main.orthographicSize * 2f;
        GameWidth = Camera.main.aspect * GameHeight;

        maxX = GameWidth / 2;
        maxY = GameHeight / 2;
        minX = -maxX;
        minY = -maxY;
    }

    // Called when the boolean for 2a is true
    void Question2a()
    {
        // Set the coordinated for starting and ending points
        startPt = new Vector2(0, 0);
        endPt = new Vector2(2, 3);

        // Draw a line between the starting and ending point stated above. Also set isActive to true
        drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, Color.red);
        drawnLine.EnableDrawing(true);
    }

    // Called when the boolean for 2b is true
    void Question2b(int n)
    {
        // Looped based on the number of lines wanted
        for (int i = 0; i < n; i++)
        {
            // Randomize the XY coordinates of the starting and ending point
            startPt = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
            endPt = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));

            // Draw a line between the starting and ending point stated above. Also set isActive to true
            drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, Color.red);
            drawnLine.EnableDrawing(true);
        }
    }
    
    // Called when the boolean for 2c is true
    void Question2c(int n)
    {
        // Looped based on the number of lines wanted
        for (int i = 0; i < n; i++)
        {
            // Randomize the XY coordinates of the starting and ending point
            startPt = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            endPt = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

            // Draw a line between the starting and ending point stated above. Also set isActive to true
            drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, Color.red);
            drawnLine.EnableDrawing(true);
        }
    }

    void Question2d()
    {
        // Create a red arrow from (0, 0, 0) to (5, 5, 0) for specified amount of seconds
        // Only visible in scene view
        DebugExtension.DebugArrow(new Vector3(0, 0, 0), new Vector3(5, 5, 0), Color.red, 10f);
    }

    void Question2e(int n)
    {
        for (int i = 0; i < n; i++)
        {
            startPt = new Vector2(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY));
            Vector3 randomPt = new Vector3(startPt.x, startPt.y, Random.Range(-maxY, maxY));

            DebugExtension.DebugArrow(new Vector3(0, 0, 0), randomPt, Color.white, 60f);
        }  
    }

    public void Question3a()
    {
        // Set the HVector values of a, b and c
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = new HVector2D(-4, 2);
        HVector2D c = a - b;

        // Draw them out using the DebugExtension plugin
        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(Vector3.zero, b.ToUnityVector3(), Color.green, 60f);
        DebugExtension.DebugArrow(Vector3.zero, c.ToUnityVector3(), Color.white, 60f);

        // Draw another arrow b but in the reversed direction, starting from the head of arrow a
        DebugExtension.DebugArrow(a.ToUnityVector3(), -b.ToUnityVector3(), Color.green, 60f);

        // Print out the magnitude of the different arrows to the console in 2 decimal place
        Debug.Log("Magnitude of a = " +  a.Magnitude().ToString("F2"));
        Debug.Log("Magnitude of a = " +  b.Magnitude().ToString("F2"));
        Debug.Log("Magnitude of a = " +  c.Magnitude().ToString("F2"));
    }

    public void Question3b()
    {
        // Create HVector2D a with a (3, 5) coordinate
        // Create HVector2D b that is twice the size of a
        // Divide the scale of a by 2
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = a * 2;
        a = a / 2;

        // Draw a as a red arrow
        // Draw b as a green arrow and offset it by 1 unit on the x axis from the point of origin
        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(Vector3.zero + new Vector3(1, 0), b.ToUnityVector3(), Color.green, 60f);
    }

    public void Question3c()
    {
        // Create HVector2D a with (3, 5) coordinate
        HVector2D a = new HVector2D(3, 5);

        // Draw a as a red arrow
        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);

        // Normalize a then draw it as a green arrow
        a.Normalize();
        DebugExtension.DebugArrow(Vector3.zero + new Vector3(1, 0), a.ToUnityVector3(), Color.green, 60f);
        Debug.Log(a.Magnitude().ToString("F2"));
    }

    public void Projection()
    {
        HVector2D a = new HVector2D(0, 0);
        HVector2D b = new HVector2D(6, 0);
        HVector2D c = new HVector2D(2, 2);

        HVector2D v1 = b - a;
        HVector2D v2 = c - a;

        HVector2D proj = v2.Projection(v1);

        DebugExtension.DebugArrow(a.ToUnityVector3(), b.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(), c.ToUnityVector3(), Color.yellow, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(), proj.ToUnityVector3(), Color.white, 60f);
    }
}
