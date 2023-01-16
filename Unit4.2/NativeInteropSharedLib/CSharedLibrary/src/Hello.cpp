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
}