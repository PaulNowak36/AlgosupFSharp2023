class Hello
{
public:
    void print();
};

extern "C"
{
#ifdef _WIN32
    __declspec(dllexport)
#endif
    void print_text();
#ifdef _WIN32
    __declspec(dllexport)
#endif
    char* make_char_buffer(int32_t number);
#ifdef _WIN32
    __declspec(dllexport)
#endif
    void free_char_buffer(char* heap_text);
}