cmake_minimum_required(VERSION 3.20.0)
project(Example LANGUAGES CSharp C)

add_executable(Example_06 Program.cs)

list(APPEND CMAKE_MODULE_PATH "${CMAKE_CURRENT_LIST_DIR}/../cuvis.csharp/")
  
include(cuvis_csharp)
SET (REQUIRED_VERSION "3.2")
if(Cuvis_VERSION LESS ${REQUIRED_VERSION})
	message(FATAL_ERROR "Cuvis_VERSION outdated. Required: ${REQUIRED_VERSION}, got: ${Cuvis_VERSION}" )
endif()
target_link_libraries(Example_06 PRIVATE cuvis::csharp)
set_property(TARGET Example_06
	PROPERTY VS_DOTNET_REFERENCES "System.Drawing"
)