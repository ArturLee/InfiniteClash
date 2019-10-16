using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;
public class Car : MonoBehaviour 
{

    public float maxTorque = 50f;
    public float brkTorque = 100f;

    public Transform centermass;
    public Transform respawnPos;


    public WheelCollider[] wheelColliders = new WheelCollider[4];
    public Transform[] tireMeshes = new Transform[4];

    private Rigidbody m_rigidBody;
    private CarAbilityController cac;
    private WaypointSystem waypointTracker;

    public float TopSpeed = 50;

    public float steer;
    public float accel;
    public float footbrake;

    private float timer = 0;

    public bool launch = false;
    
    public bool isAi = false;
    public Vector3 inticarpos;
    float currentTime=0f;
    float totaltime = 3;

    public bool startRacing = false;
    public bool receiveInput = true;

    public AudioSource engine;
    public int[] gear;

    [Range(0, 1)] [SerializeField] private float m_SteerHelper; // 0 is raw physics , 1 the car will grip in the direction it is facing
    private float m_OldRotation;

    public float CurrentSpeed{
        get{
            return m_rigidBody.velocity.magnitude * 2.23693629f;
        }
    }
    public float MaxSpeed{
        get{
            return TopSpeed;
        }
    }

    void Start()
    {
        engine = GetComponent<AudioSource>();
        cac = GetComponent<CarAbilityController>();
        m_rigidBody = GetComponent<Rigidbody>();
        m_rigidBody.centerOfMass = centermass.localPosition;
        waypointTracker = GetComponent<WaypointSystem>();
		waypointTracker.circuit = GameObject.Find("WaypointsCircuit").GetComponent<WaypointCircuit>();
    }

    void Update()
    {
        //updateMeshesPositions();
    }

    private void FixedUpdate()
    {
        EngineSound();
        if (launch) {
            LaunchUp();
        }

        if (Vector3.Dot(transform.up, Vector3.down) > 0)
        {
            timer += Time.deltaTime;
            if (timer > 3)
            {
                cac.destroy();
            }
        } else
        {
            timer = 0;
        }

        if (isAi) {
            accel = 1;
        }
        else {
            if (receiveInput) {
                if (this.gameObject.tag == "racer1")
                {
                    //Debug.Log(this.gameObject.tag);
                    steer = Input.GetAxis("player1H");
                    float accelInput = Input.GetAxis("player1V");
                    if (startRacing) {
                    accel = Mathf.Clamp(accelInput, 0, 1);
                        footbrake = -1 * Mathf.Clamp(accelInput, -1, 0); 
                    }
                }
                else if (this.gameObject.tag == "racer2")
                {
                    steer = Input.GetAxis("player2H");
                    float accelInput = Input.GetAxis("player2V");
                    if (startRacing) {
                    accel = Mathf.Clamp(accelInput, 0, 1);
                        footbrake = -1 * Mathf.Clamp(accelInput, -1, 0); 
                    }
                }
                else if (this.gameObject.tag == "racer3")
                {
                    steer = Input.GetAxis("player3H");
                    float accelInput = 0;
                    if(Input.GetKey(KeyCode.Joystick1Button7)){
                    accelInput =1;
                    }
                    if(Input.GetKey(KeyCode.Joystick1Button6)){
                        accelInput=-1;
                    }
                    if (startRacing) {
                        accel = Mathf.Clamp(accelInput, 0, 1);
                        footbrake = -1 * Mathf.Clamp(accelInput, -1, 0); 
                    }
                }
                else if (this.gameObject.tag == "racer4")
                {
                    steer = Input.GetAxis("player4H");
                    float accelInput = 0;
                    if(Input.GetKey(KeyCode.Joystick2Button7)){
                    accelInput =1;
                    }
                    if(Input.GetKey(KeyCode.Joystick2Button6)){
                        accelInput=-1;
                    }
                    if (startRacing) {
                    accel = Mathf.Clamp(accelInput, 0, 1);
                        footbrake = -1 * Mathf.Clamp(accelInput, -1, 0); 
                    }
                }
            }
        }
        if (m_rigidBody.velocity.magnitude * 3.6f <= 10)
        {
            float finalAngle = (steer) * 30f;
            wheelColliders[0].steerAngle = finalAngle;
            wheelColliders[1].steerAngle = finalAngle;
        }
        else if(m_rigidBody.velocity.magnitude * 3.6f <= 20)
        {
            float finalAngle = (steer) * 28f;
            wheelColliders[0].steerAngle = finalAngle;
            wheelColliders[1].steerAngle = finalAngle;
        }
        else if (m_rigidBody.velocity.magnitude * 3.6f <= 30)
        {
            float finalAngle = (steer) * 27f;
            wheelColliders[0].steerAngle = finalAngle;
            wheelColliders[1].steerAngle = finalAngle;
        }
        else if (m_rigidBody.velocity.magnitude * 3.6f <= 40)
        {
            float finalAngle = (steer) * 25f;
            wheelColliders[0].steerAngle = finalAngle;
            wheelColliders[1].steerAngle = finalAngle;
        }
        else if (m_rigidBody.velocity.magnitude * 3.6f <= 50)
        {
            float finalAngle = (steer) * 22f;
            wheelColliders[0].steerAngle = finalAngle;
            wheelColliders[1].steerAngle = finalAngle;
        }
        else if (m_rigidBody.velocity.magnitude * 3.6f <= 60)
        {
            float finalAngle = (steer) * 20f;
            wheelColliders[0].steerAngle = finalAngle;
            wheelColliders[1].steerAngle = finalAngle;
        }
        else if (m_rigidBody.velocity.magnitude * 3.6f <= 70)
        {
            float finalAngle = (steer) * 17f;
            wheelColliders[0].steerAngle = finalAngle;
            wheelColliders[1].steerAngle = finalAngle;
        }
        else if (m_rigidBody.velocity.magnitude * 3.6f <= 80)
        {
            float finalAngle = (steer) * 15f;
            wheelColliders[0].steerAngle = finalAngle;
            wheelColliders[1].steerAngle = finalAngle;
        }
        else if (m_rigidBody.velocity.magnitude * 3.6f <= 90)
        {
            float finalAngle = (steer) * 12f;
            wheelColliders[0].steerAngle = finalAngle;
            wheelColliders[1].steerAngle = finalAngle;
        }
        else if (m_rigidBody.velocity.magnitude * 3.6f <= 100)
        {
            float finalAngle = (steer) * 10f;
            wheelColliders[0].steerAngle = finalAngle;
            wheelColliders[1].steerAngle = finalAngle;
        }
        else if (m_rigidBody.velocity.magnitude * 3.6f <= 110)
        {
            float finalAngle = (steer) * 7f;
            wheelColliders[0].steerAngle = finalAngle;
            wheelColliders[1].steerAngle = finalAngle;
        }
        else if (m_rigidBody.velocity.magnitude * 3.6f <= 130)
        {
            float finalAngle = (steer) * 5f;
            wheelColliders[0].steerAngle = finalAngle;
            wheelColliders[1].steerAngle = finalAngle;
        }

        //---------------------------------------------- RWD ---------------------------------
        //wheelColliders[2].motorTorque = accel * maxTorque; 
        //wheelColliders[3].motorTorque = accel * maxTorque; 

        //---------------------------------------------- AWD ---------------------------------
        for (int i = 0; i < 4; i++)
        {
         wheelColliders[i].motorTorque = accel * maxTorque;
        }

        for (int i = 0; i < 4; i++)
        {
            if (CurrentSpeed > 5 && Vector3.Angle(transform.forward, m_rigidBody.velocity) < 50f)
            {
                wheelColliders[i].brakeTorque = 2*(maxTorque * footbrake);
            }
            else if (footbrake > 0)
            {
                wheelColliders[i].brakeTorque = 0f;
                wheelColliders[i].motorTorque = -maxTorque * footbrake;
            }
        }

        //Debug.Log(accel);

        if (!wheelColliders[1].isGrounded)
        {
        }
        SteerHelper();
        CarSpeed();
    }

    void updateMeshesPositions(){
        for (int i = 0; i < 4; i++){
            Quaternion q; 
            Vector3 pos;
            wheelColliders[i].GetWorldPose(out pos, out q);

            tireMeshes[i].position = pos;
            tireMeshes[i].rotation = q;
        }
    }
    void CarSpeed(){
        float speed = m_rigidBody.velocity.magnitude;
        speed *= 3.6f;
        //Debug.Log(speed);
        if (speed > TopSpeed)
        { m_rigidBody.velocity = (TopSpeed / 3.6f) * m_rigidBody.velocity.normalized; }
    }

    void SteerHelper()
    {
        for (int i = 0; i < 4; i++)
        {
            WheelHit wheelhit;
            wheelColliders[i].GetGroundHit(out wheelhit);
            if (wheelhit.normal == Vector3.zero)
                return; // wheels arent on the ground so dont realign the rigidbody velocity
        }

        // this if is needed to avoid gimbal lock problems that will make the car suddenly shift direction
        if (Mathf.Abs(m_OldRotation - transform.eulerAngles.y) < 10f)
        {
            var turnadjust = (transform.eulerAngles.y - m_OldRotation) * m_SteerHelper;
            Quaternion velRotation = Quaternion.AngleAxis(turnadjust, Vector3.up);
            m_rigidBody.velocity = velRotation * m_rigidBody.velocity;
        }
        m_OldRotation = transform.eulerAngles.y;
    }
    void LaunchUp(){
        m_rigidBody.velocity = Vector3.zero;
        m_rigidBody.angularVelocity = Vector3.zero;
        currentTime += Time.deltaTime;
        if (currentTime > totaltime)
        {
            currentTime = totaltime;

        }
        float perc = currentTime / totaltime;
        transform.position = inticarpos + new Vector3(0, Mathf.Sin(perc*Mathf.PI)*10, 0);
        if(perc == 1){
            launch = false;
            currentTime = 0;

        }
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided");
    }

    void EngineSound(){
        engine.pitch = ((m_rigidBody.velocity.magnitude * 3.6f -5) / 120 );  //120 is top speed
        //Debug.Log("audio speed pitch " + engine.pitch); 
    }
}
