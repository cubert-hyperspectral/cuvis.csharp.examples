cmake_minimum_required(VERSION 3.20.0)
project(02_reprocessMeasurement_cs LANGUAGES CSharp C)

add_executable(02_reprocessMeasurement_cs Program.cs)

list(APPEND CMAKE_MODULE_PATH "${CMAKE_CURRENT_LIST_DIR}/../cuvis.csharp/")
  
include(cuvis_csharp)
SET (REQUIRED_VERSION "3.2")
if(Cuvis_VERSION LESS ${REQUIRED_VERSION})
	message(FATAL_ERROR "Cuvis_VERSION outdated. Required: ${REQUIRED_VERSION}, got: ${Cuvis_VERSION}" )
endif()
target_link_libraries(02_reprocessMeasurement_cs PRIVATE cuvis::csharp)
set_property(TARGET 02_reprocessMeasurement_cs
	PROPERTY VS_DOTNET_REFERENCES "System.Drawing"
)