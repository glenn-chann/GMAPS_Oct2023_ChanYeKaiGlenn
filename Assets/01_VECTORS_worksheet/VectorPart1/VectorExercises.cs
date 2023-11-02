using Unity.VisualScripting;
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
    private float minX, minY, minZ, maxX, maxY, maxZ;

    private void Start()
    {
        CalculateGameDimensions();
        if (Q2a)
            Question2a();
        if (Q2b)
            Question2b(20);
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

    public void CalculateGameDimensions()
    {
        //get the game height and width 
        GameHeight = Camera.main.orthographicSize * 2f;
        GameWidth = Camera.main.aspect * GameHeight;

        //set the max and min values based on the screen size 
        maxX = GameWidth / 2;
        maxY = GameHeight / 2;
        minX = -maxX;
        minY = -maxY;
    }

    void Question2a()
    {
        //set the start and end points in the vector 
        startPt = new Vector2(0, 0);
        endPt = new Vector2(2, 3);

        //draw the line between the 2 points 
        drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, Color.black);

        drawnLine.EnableDrawing(true);

        //set vector as end point minus start point so that the vector we get 
        //will always start at the origin 
        Vector2 vec2 = endPt - startPt;
        //debug log the magnitude of the vector
        Debug.Log("Magnitude = " + vec2.magnitude);
    }

    //draw n number of random lines 
    void Question2b(int n)
    {
        for(int i = 0; i < n; i++)
        {
            //get a random vector with x and y coords between the -Max and Max valuess by using the Random.Range function to use as the start point
            startPt = new Vector2(
                Random.Range(-maxX, maxX),
                Random.Range(-maxY, maxY));

            //get a random vector using the same method to use as the end point
            endPt = new Vector2(
                Random.Range(-maxX, maxX),
                Random.Range(-maxY, maxY));

            //draw the lines using lineFactory.GetLine() function in the LineFactory script
            drawnLine = lineFactory.GetLine(
                startPt, endPt, 0.02f, Color.black);

            //enable the drawing for the created lines so we can see them
            drawnLine.EnableDrawing(true);
        }

    }

    void Question2d()
    {
        //drawing a red arrow from the origin to (5,5,0) for 60 seconds
        DebugExtension.DebugArrow(
          new Vector3(0, 0, 0),
          new Vector3(5, 5, 0),
          Color.red,
          60f);
    }

    //drawing n number of random arrows 
    void Question2e(int n)
    {
        for (int i = 0; i < n; i++)
        {
            //randomising the end point using Random.Range function and the values of -Max and Max
            endPt = new Vector3(
                Random.Range(-maxX, maxX), 
                Random.Range(-maxY, maxY),
                Random.Range(-maxZ, maxZ));

            //draw an arrow from the origin to the randomised end point 
            DebugExtension.DebugArrow(
            new Vector3(0, 0, 0),
            endPt,
            Color.red,
            60f);
        }  
    }

    public void Question3a()
    {

        HVector2D a = new HVector2D(3, 5);
        HVector2D b = new HVector2D(-4, 2);
        HVector2D c = a - b;

        //drawing the vectors a b and c with the starting point being the origin 
        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(Vector3.zero, b.ToUnityVector3(), Color.green, 60f);
        DebugExtension.DebugArrow(Vector3.zero, c.ToUnityVector3(), Color.white, 60f);

        //drawing b again but with the starting position of the head of vector a and flipped 
        DebugExtension.DebugArrow(a.ToUnityVector3(), -b.ToUnityVector3(), Color.green, 60f);

        //printing magnitudes of the Vectors 
        Debug.Log("Magnitude of a = " + a.Magnitude().ToString("F2"));
        Debug.Log("Magnitude of b = " + b.Magnitude().ToString("F2"));
        Debug.Log("Magnitude of c = " + c.Magnitude().ToString("F2"));
    }

    public void Question3b()
    {
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = a * 2;
        a /= 2;

        //drawing vector a with the start point being the origin 
        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        //drawing vector b with the start point being the origin offsetted by 1 on the x axis 
        DebugExtension.DebugArrow(Vector3.right, b.ToUnityVector3(), Color.green, 60f);
    }

    public void Question3c()
    {
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = a.Normalize();

        //drawing vector a with the start point being the origin
        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        //drawing vector b with the start point being the origin offsetted by 1 on the x axis 
        DebugExtension.DebugArrow(Vector3.right, b.ToUnityVector3(), Color.green, 60f);

        //printing the magnitude of vector b 
        Debug.Log("Magnitude of b = " + b.Magnitude().ToString("F2"));
    }

    public void Projection()
    {
        HVector2D a = new HVector2D(0, 0);
        HVector2D b = new HVector2D(6, 0);
        HVector2D c = new HVector2D(2, 2);

        //getting the projection of c onto b 
        HVector2D proj = b * (c.DotProduct(b) / b.DotProduct(b));

        //drawing vectors b, c and the projection
        DebugExtension.DebugArrow(a.ToUnityVector3(), b.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(), c.ToUnityVector3(), Color.yellow, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(), proj.ToUnityVector3(), Color.white, 60f);
    }
}
