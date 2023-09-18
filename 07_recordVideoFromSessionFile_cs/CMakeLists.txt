cmake_minimum_required(VERSION 3.16.0)
project(07_recordVideoFromSessionFile_cs LANGUAGES CSharp C)

add_executable(07_recordVideoFromSessionFile_cs Program.cs)

list(APPEND CMAKE_MODULE_PATH "${CMAKE_CURRENT_LIST_DIR}/../cuvis.csharp/")
  
include(cuvis_csharp)
SET (REQUIRED_VERSION "3.2")
if(Cuvis_VERSION LESS ${REQUIRED_VERSION})
	message(FATAL_ERROR "Cuvis_VERSION outdated. Required: ${REQUIRED_VERSION}, got: ${Cuvis_VERSION}" )
endif()
target_link_libraries(07_recordVideoFromSessionFile_cs PRIVATE cuvis::csharp)
set_property(TARGET 07_recordVideoFromSessionFile_cs
	PROPERTY VS_DOTNET_REFERENCES "System.Drawing;System.Diagnostics"
)