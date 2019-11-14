#include "interface.hpp"

uint32_t g_value;
unityFunc_t g_func;

void SetValueInPlugin(uint32_t value)
{
    g_value = value;
}

uint32_t GetValueFromPlugin()
{
    return g_value;
}

void SetUnityFunction(unityFunc_t func)
{
    g_func = func;
}

void CallUnityFunction()
{
    g_value = g_func(g_value);
}
