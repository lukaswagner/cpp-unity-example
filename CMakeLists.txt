cmake_minimum_required(VERSION 3.0)

# project settings

project(plugin CXX)

set(CMAKE_CXX_STANDARD 14)
set(CMAKE_CXX_STANDARD_REQUIRED ON)
set(CMAKE_CXX_EXTENSIONS OFF)

# sources

set(source_dir src)
set(include_dir include)
set(generated_header_dir ${CMAKE_BINARY_DIR}/generated)

set(export_header
    ${generated_header_dir}/${PROJECT_NAME}_export.hpp)

set(public_headers
    ${include_dir}/interface.hpp
    ${export_header})

set(private_headers "")

set(sources
    ${source_dir}/plugin.cpp)

# lib target

include_directories(${generated_header_dir})
include_directories(${include_dir})

add_library(${PROJECT_NAME} SHARED
    ${public_headers}
    ${private_headers}
    ${sources})

include(GenerateExportHeader)
string(TOUPPER ${PROJECT_NAME} project_name_upper)
generate_export_header(${PROJECT_NAME}
    BASE_NAME ${PROJECT_NAME}
    EXPORT_MACRO_NAME ${project_name_upper}_EXPORT
    EXPORT_FILE_NAME ${export_header}
    STATIC_DEFINE ${project_name_upper}_BUILT_AS_STATIC)

# install settings

set_target_properties(${PROJECT_NAME} PROPERTIES PUBLIC_HEADER "${public_headers}")

include(GNUInstallDirs)
install(TARGETS ${PROJECT_NAME}
    LIBRARY DESTINATION ${CMAKE_INSTALL_LIBDIR}
    ARCHIVE DESTINATION ${CMAKE_INSTALL_LIBDIR}
    RUNTIME DESTINATION ${CMAKE_INSTALL_LIBDIR}
    PUBLIC_HEADER DESTINATION ${CMAKE_INSTALL_INCLUDEDIR})
