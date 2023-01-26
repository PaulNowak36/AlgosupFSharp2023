#include <stdio.h>
#include <stdlib.h>
#include <cstring>
#include <string>
#include <iostream>

#include "shared/Hello.h"

extern "C"
{
#ifdef _WIN32
    __declspec(dllexport)
#endif
    void print_text()
    {
        std::cout << "Hello Shared Library!" << std::endl;
    }

#ifdef _WIN32
    __declspec(dllexport)
#endif
    char* make_char_buffer(int32_t number)
    {
        std::string prefix = "My number is ";
        std::string result = prefix + std::to_string(number);

        char *buffer = strdup(result.c_str());
        return buffer;
    }

#ifdef _WIN32
    __declspec(dllexport)
#endif
    void free_char_buffer(char* heap_text)
    {
        free(heap_text);
    }

#ifdef _WIN32
    __declspec(dllexport)
#endif
    void int_pointer_demo(int32_t* number)
    {
        *number = 42;
    }

#ifdef _WIN32
    __declspec(dllexport)
#endif
    void char_buffer_demo(char* buffer, int32_t* char_count)
    {
        strcpy(buffer, "Hello, world");
        *char_count = 12;
    }

#ifdef _WIN32
    __declspec(dllexport)
#endif
    void struct_demo(Point* point)
    {
        point->x = 12;
        point->y = 13;
    }

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
}