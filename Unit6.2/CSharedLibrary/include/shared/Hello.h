class Hello
{
public:
    void print();
};

extern "C"
{
struct Point
{
   int32_t x, y;
};

#ifdef _WIN32
    __declspec(dllexport)
#endif
    void int_pointer_demo(int32_t* number);

#ifdef _WIN32
    __declspec(dllexport)
#endif
    void char_buffer_demo(char* buffer, int32_t* char_count);

#ifdef _WIN32
    __declspec(dllexport)
#endif
    void struct_demo(Point* point);

#ifdef _WIN32
    __declspec(dllexport)
#endif
    void struct_buffer_demo(Point* points, int32_t* elements);
}