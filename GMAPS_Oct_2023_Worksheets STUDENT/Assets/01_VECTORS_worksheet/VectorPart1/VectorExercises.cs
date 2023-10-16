using UnityEngine;

public class VectorExercises : MonoBehaviour
{
    [SerializeField] LineFactory lineFactory;
    [SerializeField] bool Q2a, Q2b, Q2d, Q2e;
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
    
    // Called when the boolean for 2b is true
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

    }

    void Question2e(int n)
    {
        for (int i = 0; i < n; i++)
        {
            startPt = new Vector2(
                Random.Range(-maxX, maxX), 
                Random.Range(-maxY, maxY));

            // Your code here
            // ...

            //DebugExtension.DebugArrow(
            //    new Vector3(0, 0, 0),
            //    // Your code here,
            //    Color.white,
            //    60f);
        }  
    }

    public void Question3a()
    {
        HVector2D a = new HVector2D(3, 5);
        //HVector2D b = // Your code here;
        //HVector2D c = // Your code here;

        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        // Your code here
        // ...

        // Your code here

        //Debug.Log("Magnitude of a = " + // Your code here.ToString("F2"));
        // Your code here
        // ...
    }

    public void Question3b()
    {
        // Your code here
        // ...

        //DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        // Your code here
    }

    public void Question3c()
    {

    }

    public void Projection()
    {
        HVector2D a = new HVector2D(0, 0);
        HVector2D b = new HVector2D(6, 0);
        HVector2D c = new HVector2D(2, 2);

        //HVector2D v1 = b - a;
        // Your code here

        //HVector2D proj = // Your code here

        //DebugExtension.DebugArrow(a.ToUnityVector3(), b.ToUnityVector3(), Color.red, 60f);
        //DebugExtension.DebugArrow(a.ToUnityVector3(), c.ToUnityVector3(), Color.yellow, 60f);
        //DebugExtension.DebugArrow(a.ToUnityVector3(), proj.ToUnityVector3(), Color.white, 60f);
    }
}
