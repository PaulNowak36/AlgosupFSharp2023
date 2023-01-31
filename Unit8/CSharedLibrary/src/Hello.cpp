#include <stdio.h>
#include <stdlib.h>
#include <cstring>
#include <string>
#include <iostream>

#include "shared/Hello.h"

class Animal
{
public:
   Animal(std::string sound, int legs)
   {
      _legs = legs;
      _sound = sound;
   }

   void doSound()
   {
            std::cout << "Sound: " << _sound << std::endl;
   }
   void showLegs()
   {
            std::cout << "Legs: " << _legs << std::endl;
   }

private:
   std::string _sound;
   int _legs;
};


extern "C"
{
#ifdef _WIN32
    __declspec(dllexport)
#endif
    void struct_buffer_demo(Point* points, int32_t* elements)
    {
        const int32_t elements_to_fill = 25;
        int32_t i;
        for (i = 0; i < elements_to_fill; i++)
        {
            points[i].x = i;
            points[i].y = i;
        }
        *elements = elements_to_fill;
    }

#ifdef _WIN32
    __declspec(dllexport)
#endif
    void struct_pointer_buffer_demo(Point** pPoints, int32_t* elements)
    {
        const int32_t elements_to_fill = 25;

        *pPoints = (Point *)malloc(elements_to_fill * sizeof(Point));

        Point* points = *pPoints;

        int32_t i;
        for (i = 0; i < elements_to_fill; i++)
        {
            points[i].x = i;
            points[i].y = i;
        }
        *elements = elements_to_fill;
    }

#ifdef _WIN32
    __declspec(dllexport)
#endif
    void input_struct_buffer_demo(Point* points, int32_t elements)
    {
        int32_t i;
        for (i = 0; i < elements; i++)
        {
            std::cout << "x = " << points[i].x << ", y = " << points[i].y << std::endl;
        }
    }

#ifdef _WIN32
    __declspec(dllexport)
#endif
    void free_points_buffer(Point** pPoints)
    {
        free(*pPoints);
    }

#ifdef _WIN32
    __declspec(dllexport)
#endif
    Animal* new_animal(char* soundCharBuffer, int32_t legs)
    {
        std::string sound(soundCharBuffer);
        return new Animal(sound, legs);
    }

#ifdef _WIN32
    __declspec(dllexport)
#endif
    void delete_animal(Animal* animal)
    {
        delete animal;
    }

#ifdef _WIN32
    __declspec(dllexport)
#endif
    void animal_do_sound(Animal* animal)
    {
        animal->doSound();
    }

#ifdef _WIN32
    __declspec(dllexport)
#endif
    void animal_show_legs(Animal* animal)
    {
        animal->showLegs();
    }

}