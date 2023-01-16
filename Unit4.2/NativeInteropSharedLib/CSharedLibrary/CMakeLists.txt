cmake_minimum_required(VERSION 3.5)

project(hello_library)

if(NOT MSVC)
    set(CMAKE_VERBOSE_MAKEFILE ON)
    SET(CMAKE_CXX_FLAGS "-std=gnu++0x")
endif()

############################################################
# Create a library
############################################################
#Generate the shared library from the library sources
add_library(hello_library SHARED
    src/Hello.cpp
)
add_library(hello::library ALIAS hello_library)


target_include_directories(hello_library
    PUBLIC
        ${PROJECT_SOURCE_DIR}/include
)
