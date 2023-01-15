class Hello
{
public:
    void print();
};

extern "C"
{
    __declspec(dllexport) void print_text();
    __declspec(dllexport) char* make_char_buffer(int32_t number);
    __declspec(dllexport) void free_char_buffer(char* heap_text);
}