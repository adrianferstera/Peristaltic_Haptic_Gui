# Peristaltic Haptic GUI

This C# solution was part of my master thesis in mechanical Engineering. It was a collaboration between ETH Zurich and the University of California at Santa Barbara.  

### Master Thesis
Thesis: Multichannel Hydraulic Control for Textile-Based Soft Robotics
Supervisor: [Retouch Lab](http://re-touch-lab.com/), CNSI, University of California at Santa Barbara 

### Description
This solution creates a graphical user interface (GUI) to control 8 HerkuleX Smart Robot Servos asynchronously. Each servo is connected to a low pressure pump which is then connected to a wearable sleeve.
By increasing the pressure inside the tube, the tube elongates and vice versa. With this increasing and decreasing procedure, different kind of wave patterns can be applied to the wearable sleeve. 

### Using the Herkulex Gui Mapper 
This class uses 8 HerkuleX DRS 0602 to asynchrounsly perform different kind of wave patterns on the wearable sleeve.  Therefore, the 8 servos need to have ID's between 1 and 8. 

## Installation 

*  Download the solution 
*  Open the solution in Visual Studio 
*  Build the Solution
*  Open the Unit Test Project

## Using the software

Following examples can be used to run the servos. All examples below can be found in the Unit Test Folder. 
Please have a look in my other repository for a better explanation of using the HerkuleX API. 


## Examples


```
// Initialize all interfaces first. In this example, always two servos are connected to one interface. 
 var myHerkulexInterface12 = new HerkulexInterface("COM11", 57600);
 var myHerkulexInterface34 = new HerkulexInterface("COM12", 57600);
 var myHerkulexInterface56 = new HerkulexInterface("COM13", 57600);
 var myHerkulexInterface78 = new HerkulexInterface("COM14", 57600);

 // Initialize all servos with its unique id and the interface they communicate through
 var myServo1 = new HerkulexDrs0602(1, myHerkulexInterface12);
 var myServo2 = new HerkulexDrs0602(2, myHerkulexInterface12);
 var myServo3 = new HerkulexDrs0602(3, myHerkulexInterface34);
 var myServo4 = new HerkulexDrs0602(4, myHerkulexInterface34);
 var myServo5 = new HerkulexDrs0602(5, myHerkulexInterface56);
 var myServo6 = new HerkulexDrs0602(6, myHerkulexInterface56);
 var myServo7 = new HerkulexDrs0602(7, myHerkulexInterface78);
 var myServo8 = new HerkulexDrs0602(8, myHerkulexInterface78);

 // Make a list with all interfaces and servos
 var myServos = new List<IHerkulexServo>() { myServo1, myServo2, myServo3, myServo4, myServo5, myServo6, myServo7, myServo8 };
 var myInterfaces = new List<HerkulexInterface>() { myHerkulexInterface12, myHerkulexInterface34, myHerkulexInterface56, myHerkulexInterface78 };

// Enable torque and adjust the servos neutral position (depending on the application)
 foreach (var servo in myServos)
 {
     servo.TorqueOn();
     servo.NeutralPosition = -60;
 }

 // Initialize an instance of the Herkulex Async Replayer by defining the servos limits (depending on its application)
var replayer = new HerkulexAsyncReplayer(-60, 0);

// Perform a sine waveform sequence with frequency 0.5, maximal possible amplitude of 1, 
// current amplitude of 1, how many times this sequence should be repeated (here 10 times), for the servos defined in the list `myServos`
replayer.StartSeries(WaveformType.Sine, 0.5, 1, 1, 10, myServos);
```


## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details


