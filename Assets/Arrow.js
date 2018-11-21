#pragma strict

//скрипт стрелы, баллистическая траектория+застревание в цели.


function Start () {
        //смещение центра тяжести по оси z
        GetComponent.<Rigidbody>().centerOfMass = Vector3 (0, 0, 5);
}
        // функция проверки столкновения
function OnCollisionEnter (collision : Collision) {
       // отключение физики стрелы включение кинематики
       if(collision.gameObject.tag == "Explosions"){
        GetComponent.<Rigidbody>().isKinematic = true;
       // координаты стрелы присоединяются к координатам объекта столкновения.
        transform.parent = collision.transform;
        }
}

@script RequireComponent (Rigidbody)