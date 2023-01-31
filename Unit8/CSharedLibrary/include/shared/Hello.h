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
   void struct_buffer_demo(Point* points, int32_t* elements);

#ifdef _WIN32
    __declspec(dllexport)
#endif
    void struct_pointer_buffer_demo(Point** pPoints, int32_t* elements);

#ifdef _WIN32
    __declspec(dllexport)
#endif
    void input_struct_buffer_demo(Point* pPoints, int32_t elements);

#ifdef _WIN32
    __declspec(dllexport)
#endif
    void free_points_buffer(Point** pPoints);
}