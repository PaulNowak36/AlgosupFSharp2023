#include <stdio.h>
#include <stdlib.h>
#include <string>
#include <iostream>

#include "shared/Hello.h"

extern "C"
{
    __declspec(dllexport) void print_text()
    {
        std::cout << "Hello Shared Library!" << std::endl;
    }

    __declspec(dllexport) char* make_char_buffer(int32_t number)
    {
        std::string prefix = "My number is ";
        std::string result = prefix + std::to_string(number);

        char *buffer = _strdup(result.c_str());
        return buffer;
    }

    __declspec(dllexport) void free_char_buffer(char* heap_text)
    {
        free(heap_text);
    }
}