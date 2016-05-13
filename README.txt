Video Files:

	As per Professor Ouda's instructions the video files have been deleted from the reasources folder in my assignment submission. 

	For testing, the video files "video1.mjpeg" and "video2.mjpeg" should be placed in the Reasources folder in the project.

	So store them at the path: "WhereverYouPlaceTheAssignment1Folder"\assignment1_rstirli2\StreamingServer\Resources\

	In the Model-RTP class the setInfo function must then be modified to have the full path on your computer. On mine setting the path looks like this

	fs = File.OpenRead("C:\\Users\\rusty_000\\Documents\\Visual Studio 2012\\Projects\\3314Assignment1\\StreamingServer\\Resources\\"+_path);

	Replace that in yours with:

	fs = File.OpenRead("'ThePathToAssignment1Folder'\\assignment1_rstirli2\\StreamingServer\\Resources\\"+_path);

	Make sure to use the double \\ to avoid errors.

How To Use Application:

	Open the application.

	Enter the port number in the port text box (default is 3000)

	Click listen

	1: Open a client

	   Ensure the port number is the same in client as in server

       	   Click connect

	   Server will display message saying connected to the client and waiting for another client to connect

	Repeat from 1 for however many clients you want

	2: Select the video file you want to play on the client

	   Click SETUP to prepare the video

	   Click PLAY to start the video playing

	   While playing click PAUSE to pause the video

	   Once SETUP click teardown to stop the video. Then repeat from 2 to see other videos

	Server will display all command message in the client request box for SETUP, PLAY, PAUSE, and TEARDOWN

	At any point click the "RTP Header" check box to display the RTP headers being sent to the client while the video is playing

	If you let a video play to completion you can return to step 2 to choose another video

	Closing the client will cause the client server tcp connection for that client to close without affecting other clients.

	Close the server by hitting the red "X" in the top right corner (All client videos will stop playing if you do this)

If you run into any problems please email me at russell.k.stirling@gmail.com