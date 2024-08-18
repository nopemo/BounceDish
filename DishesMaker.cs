using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishesMaker : MonoBehaviour
{
    [SerializeField] private Vector2 angle_range = new Vector2(-90, 90);
    [SerializeField] private float average_duration = 1.0f;
    [SerializeField] private Vector2 shoot_duration_range = new Vector2(-0.5f, 0.5f);
    [SerializeField] private Vector2 strike_duration_range = new Vector2(-0.5f, 0.5f);
    [SerializeField] private float average_speed = 1.0f;
    [SerializeField] private float radius = 30f;

    [SerializeField] private GameObject dish;
    private float angle;
    private float start_time;
    private float shoot_span;
    private float speed;
    private int shoot_interval_count;

    void Start()
    {
        start_time = Time.time;
        shoot_interval_count = 0;
        SetShootTime();
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Time.time > shoot_span + start_time)
        {
            Shoot();
            SetShootTime();
        }
    }
    void Shoot()
    {
        // 原点に向かって飛ばす
        shoot_interval_count++;
        float random_angle = Random.Range(angle_range.x, angle_range.y);
        Vector3 generate_position = new Vector3(radius * Mathf.Cos(Mathf.Deg2Rad * (random_angle)), radius * Mathf.Sin(Mathf.Deg2Rad * (random_angle)), 0f);
        GameObject new_dish = Instantiate(dish, generate_position, Quaternion.Euler(0, 0, random_angle));
        new_dish.GetComponent<Rigidbody2D>().AddForce(-new_dish.transform.right * speed, ForceMode2D.Impulse);
    }
    void SetShootTime()
    {
        float shoot_duration = Random.Range(shoot_duration_range.x, shoot_duration_range.y);
        float strike_duration = Random.Range(strike_duration_range.x, strike_duration_range.y);
        speed = radius / (radius / average_speed + strike_duration - shoot_duration);
        shoot_span = average_duration * shoot_interval_count + shoot_duration;
        if (shoot_span < 0)
        {
            shoot_span += average_duration;
            shoot_interval_count++;
            if (shoot_span < 0)
            {
                // エラーを吐く
                Debug.LogError("Shoot span is invalid");
            }
        }
    }
}
