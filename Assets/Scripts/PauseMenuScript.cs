using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField]
    private GameObject content;
    [SerializeField]
    private GameObject compass;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            content.SetActive( ! content.activeSelf );
        }
    }

    public void OnCompassToggle(Boolean value)
    {
        compass.SetActive(value);
    }
}
/* Д.З. Меню паузи та налаштування
 * Реалізувати блок кнопок:
 * - Повернутись до гри
 * - Закрити програму (вихід)
 * - Відновити налаштування за замовчанням
 * - Зберегти налаштування
 * ! Закриття програми залежить від способу
 * запуску - через редактор чи самостійною 
 * програмою 
 * + Підібрати звуки (підготувати до наступного заняття)
 * - фонова музика
 * - звукові ефекти (кроки, збирання монети тощо)
 */