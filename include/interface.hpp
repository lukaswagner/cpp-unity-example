#pragma once

#include <cstdint>
#include "plugin_export.hpp"

typedef uint32_t (*unityFunc_t)(uint32_t);

extern "C"
{
    void PLUGIN_EXPORT SetValueInPlugin(uint32_t value);
    uint32_t PLUGIN_EXPORT GetValueFromPlugin();
    void PLUGIN_EXPORT SetUnityFunction(unityFunc_t func);
    void PLUGIN_EXPORT CallUnityFunction();
};
