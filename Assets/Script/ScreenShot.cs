using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{
    // Start is called before the first frame update
    private int screenshotCount = 0;
    public static int ss;
        
     // Check for screenshot key each frame
     void Update()
     {
         // take screenshot on touch
 
          if (Input.touches.Length > 5)
         {       
             string screenshotFilename;
             do
             {
                 screenshotCount++;
                 screenshotFilename = "screenshot" + screenshotCount + ".png";
                //  ss +=1;
 
             } while (System.IO.File.Exists(screenshotFilename));
             
           //  audio.Play();
             
             ScreenCapture.CaptureScreenshot(screenshotFilename);
         }
     }
}
