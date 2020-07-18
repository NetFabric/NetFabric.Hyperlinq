## ArrayDistinct

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET 4.8      : .NET Framework 4.8 (4.8.4180.0), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT


```
|      Method |           Job |       Runtime | Count |          Mean |       Error |      StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |-------------- |-------------- |------ |--------------:|------------:|------------:|------:|--------:|--------:|------:|------:|----------:|
|     **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **0** |     **11.142 ns** |   **0.0968 ns** |   **0.0858 ns** |  **1.00** |    **0.00** |  **0.0306** |     **-** |     **-** |      **64 B** |
| ForeachLoop |      .NET 4.8 |      .NET 4.8 |     0 |     11.162 ns |   0.1154 ns |   0.0901 ns |  1.00 |    0.01 |  0.0306 |     - |     - |      64 B |
|        Linq |      .NET 4.8 |      .NET 4.8 |     0 |     67.091 ns |   0.4140 ns |   0.3457 ns |  6.03 |    0.04 |  0.1415 |     - |     - |     297 B |
|  StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |    200.579 ns |   1.2363 ns |   1.0960 ns | 18.00 |    0.19 |       - |     - |     - |         - |
|   Hyperlinq |      .NET 4.8 |      .NET 4.8 |     0 |     77.149 ns |   0.5436 ns |   0.4540 ns |  6.93 |    0.07 |       - |     - |     - |         - |
|     ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |      8.214 ns |   0.1168 ns |   0.1093 ns |  0.74 |    0.01 |  0.0306 |     - |     - |      64 B |
| ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |      8.285 ns |   0.1295 ns |   0.1211 ns |  0.74 |    0.01 |  0.0306 |     - |     - |      64 B |
|        Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |     34.416 ns |   0.3953 ns |   0.3698 ns |  3.08 |    0.04 |  0.0306 |     - |     - |      64 B |
|  StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |    139.439 ns |   1.2297 ns |   1.1503 ns | 12.52 |    0.13 |       - |     - |     - |         - |
|   Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |     0 |     58.443 ns |   0.4231 ns |   0.3958 ns |  5.25 |    0.05 |       - |     - |     - |         - |
|     ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |      6.487 ns |   0.0645 ns |   0.0604 ns |  0.58 |    0.01 |  0.0344 |     - |     - |      72 B |
| ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |      6.792 ns |   0.0992 ns |   0.0774 ns |  0.61 |    0.01 |  0.0344 |     - |     - |      72 B |
|        Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |     35.720 ns |   0.1207 ns |   0.1070 ns |  3.21 |    0.03 |  0.0306 |     - |     - |      64 B |
|  StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |    116.955 ns |   0.6299 ns |   0.5260 ns | 10.51 |    0.07 |       - |     - |     - |         - |
|   Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |     0 |     37.983 ns |   0.1842 ns |   0.1538 ns |  3.41 |    0.04 |       - |     - |     - |         - |
|             |               |               |       |               |             |             |       |         |         |       |       |           |
|     **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **1** |     **44.240 ns** |   **0.2911 ns** |   **0.2580 ns** |  **1.00** |    **0.00** |  **0.0803** |     **-** |     **-** |     **168 B** |
| ForeachLoop |      .NET 4.8 |      .NET 4.8 |     1 |     44.656 ns |   0.3544 ns |   0.3315 ns |  1.01 |    0.01 |  0.0803 |     - |     - |     168 B |
|        Linq |      .NET 4.8 |      .NET 4.8 |     1 |     87.635 ns |   1.2299 ns |   1.0270 ns |  1.98 |    0.03 |  0.1568 |     - |     - |     329 B |
|  StructLinq |      .NET 4.8 |      .NET 4.8 |     1 |    217.522 ns |   1.0190 ns |   0.9532 ns |  4.92 |    0.04 |       - |     - |     - |         - |
|   Hyperlinq |      .NET 4.8 |      .NET 4.8 |     1 |    271.744 ns |   0.9471 ns |   0.8859 ns |  6.14 |    0.05 |       - |     - |     - |         - |
|     ForLoop | .NET Core 3.1 | .NET Core 3.1 |     1 |     34.764 ns |   0.3419 ns |   0.3031 ns |  0.79 |    0.01 |  0.0803 |     - |     - |     168 B |
| ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     1 |     34.954 ns |   0.1910 ns |   0.1693 ns |  0.79 |    0.01 |  0.0803 |     - |     - |     168 B |
|        Linq | .NET Core 3.1 | .NET Core 3.1 |     1 |     82.304 ns |   0.5003 ns |   0.4178 ns |  1.86 |    0.01 |  0.1491 |     - |     - |     312 B |
|  StructLinq | .NET Core 3.1 | .NET Core 3.1 |     1 |    151.209 ns |   2.0739 ns |   1.8385 ns |  3.42 |    0.04 |       - |     - |     - |         - |
|   Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |     1 |    163.268 ns |   1.6333 ns |   1.3639 ns |  3.69 |    0.03 |       - |     - |     - |         - |
|     ForLoop | .NET Core 5.0 | .NET Core 5.0 |     1 |     33.568 ns |   0.2324 ns |   0.1814 ns |  0.76 |    0.01 |  0.0842 |     - |     - |     176 B |
| ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     1 |     34.179 ns |   0.2362 ns |   0.2094 ns |  0.77 |    0.01 |  0.0842 |     - |     - |     176 B |
|        Linq | .NET Core 5.0 | .NET Core 5.0 |     1 |     85.126 ns |   0.7301 ns |   0.5700 ns |  1.93 |    0.02 |  0.1491 |     - |     - |     312 B |
|  StructLinq | .NET Core 5.0 | .NET Core 5.0 |     1 |    124.919 ns |   0.8003 ns |   0.7486 ns |  2.82 |    0.02 |       - |     - |     - |         - |
|   Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |     1 |    134.637 ns |   0.6550 ns |   0.6127 ns |  3.04 |    0.02 |       - |     - |     - |         - |
|             |               |               |       |               |             |             |       |         |         |       |       |           |
|     **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |    **10** |    **264.381 ns** |   **2.8070 ns** |   **2.6256 ns** |  **1.00** |    **0.00** |  **0.3171** |     **-** |     **-** |     **666 B** |
| ForeachLoop |      .NET 4.8 |      .NET 4.8 |    10 |    267.003 ns |   3.3077 ns |   2.7621 ns |  1.01 |    0.01 |  0.3171 |     - |     - |     666 B |
|        Linq |      .NET 4.8 |      .NET 4.8 |    10 |    348.520 ns |   1.4133 ns |   1.2529 ns |  1.32 |    0.01 |  0.2980 |     - |     - |     626 B |
|  StructLinq |      .NET 4.8 |      .NET 4.8 |    10 |    614.169 ns |   3.4524 ns |   3.2294 ns |  2.32 |    0.03 |       - |     - |     - |         - |
|   Hyperlinq |      .NET 4.8 |      .NET 4.8 |    10 |    530.081 ns |   3.5791 ns |   3.3479 ns |  2.01 |    0.03 |       - |     - |     - |         - |
|     ForLoop | .NET Core 3.1 | .NET Core 3.1 |    10 |    235.806 ns |   3.3548 ns |   3.1381 ns |  0.89 |    0.01 |  0.3173 |     - |     - |     664 B |
| ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |    10 |    233.878 ns |   2.2872 ns |   2.1394 ns |  0.88 |    0.01 |  0.3171 |     - |     - |     664 B |
|        Linq | .NET Core 3.1 | .NET Core 3.1 |    10 |    349.943 ns |   3.8643 ns |   3.6147 ns |  1.32 |    0.02 |  0.2904 |     - |     - |     608 B |
|  StructLinq | .NET Core 3.1 | .NET Core 3.1 |    10 |    404.715 ns |   5.1693 ns |   4.8353 ns |  1.53 |    0.02 |       - |     - |     - |         - |
|   Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |    10 |    288.092 ns |   2.5307 ns |   2.3672 ns |  1.09 |    0.01 |       - |     - |     - |         - |
|     ForLoop | .NET Core 5.0 | .NET Core 5.0 |    10 |    187.130 ns |   1.7870 ns |   1.6715 ns |  0.71 |    0.01 |  0.3211 |     - |     - |     672 B |
| ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |    10 |    180.878 ns |   1.6265 ns |   1.4418 ns |  0.69 |    0.01 |  0.3211 |     - |     - |     672 B |
|        Linq | .NET Core 5.0 | .NET Core 5.0 |    10 |    324.782 ns |   2.6332 ns |   2.4631 ns |  1.23 |    0.01 |  0.2904 |     - |     - |     608 B |
|  StructLinq | .NET Core 5.0 | .NET Core 5.0 |    10 |    344.857 ns |   2.8488 ns |   2.6648 ns |  1.30 |    0.02 |       - |     - |     - |         - |
|   Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |    10 |    256.815 ns |   4.9332 ns |   4.8451 ns |  0.97 |    0.02 |       - |     - |     - |         - |
|             |               |               |       |               |             |             |       |         |         |       |       |           |
|     **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |  **1000** | **19,602.118 ns** | **106.2323 ns** |  **99.3698 ns** |  **1.00** |    **0.00** | **27.7710** |     **-** |     **-** |   **58880 B** |
| ForeachLoop |      .NET 4.8 |      .NET 4.8 |  1000 | 19,458.856 ns |  92.0218 ns |  81.5749 ns |  0.99 |    0.01 | 27.7710 |     - |     - |   58880 B |
|        Linq |      .NET 4.8 |      .NET 4.8 |  1000 | 24,719.220 ns | 227.9408 ns | 213.2160 ns |  1.26 |    0.01 | 15.8081 |     - |     - |   33234 B |
|  StructLinq |      .NET 4.8 |      .NET 4.8 |  1000 | 19,824.115 ns | 142.4459 ns | 133.2440 ns |  1.01 |    0.01 |       - |     - |     - |         - |
|   Hyperlinq |      .NET 4.8 |      .NET 4.8 |  1000 | 30,612.554 ns | 204.2887 ns | 181.0966 ns |  1.56 |    0.01 |       - |     - |     - |         - |
|     ForLoop | .NET Core 3.1 | .NET Core 3.1 |  1000 | 17,251.879 ns | 197.8900 ns | 185.1064 ns |  0.88 |    0.01 | 27.7710 |     - |     - |   58664 B |
| ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |  1000 | 17,170.782 ns | 310.9056 ns | 275.6097 ns |  0.88 |    0.02 | 27.7710 |     - |     - |   58664 B |
|        Linq | .NET Core 3.1 | .NET Core 3.1 |  1000 | 23,408.442 ns | 120.8543 ns | 113.0471 ns |  1.19 |    0.01 | 15.7776 |     - |     - |   33104 B |
|  StructLinq | .NET Core 3.1 | .NET Core 3.1 |  1000 | 16,797.474 ns |  86.3825 ns |  80.8023 ns |  0.86 |    0.00 |       - |     - |     - |         - |
|   Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |  1000 | 15,017.954 ns |  66.4123 ns |  51.8504 ns |  0.77 |    0.00 |       - |     - |     - |         - |
|     ForLoop | .NET Core 5.0 | .NET Core 5.0 |  1000 | 13,240.777 ns |  64.2767 ns |  60.1244 ns |  0.68 |    0.00 | 27.7710 |     - |     - |   58672 B |
| ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |  1000 | 12,918.823 ns |  51.0804 ns |  42.6545 ns |  0.66 |    0.00 | 27.7710 |     - |     - |   58672 B |
|        Linq | .NET Core 5.0 | .NET Core 5.0 |  1000 | 22,698.792 ns | 169.2554 ns | 158.3216 ns |  1.16 |    0.01 | 15.7776 |     - |     - |   33104 B |
|  StructLinq | .NET Core 5.0 | .NET Core 5.0 |  1000 | 15,914.436 ns | 174.4236 ns | 163.1560 ns |  0.81 |    0.01 |       - |     - |     - |         - |
|   Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |  1000 | 13,687.213 ns |  71.0715 ns |  63.0031 ns |  0.70 |    0.01 |       - |     - |     - |         - |

## ArraySelect

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET 4.8      : .NET Framework 4.8 (4.8.4180.0), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT


```
|               Method |           Job |       Runtime | Count |           Mean |      Error |     StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |-------------- |-------------- |------ |---------------:|-----------:|-----------:|-------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **0** |      **0.5717 ns** |  **0.0199 ns** |  **0.0186 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |     0 |      0.2628 ns |  0.0250 ns |  0.0221 ns |   0.46 |    0.04 |      - |     - |     - |         - |
|                 Linq |      .NET 4.8 |      .NET 4.8 |     0 |     31.0638 ns |  0.3119 ns |  0.2918 ns |  54.38 |    1.80 | 0.0268 |     - |     - |      56 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |     0 |      6.7561 ns |  0.0463 ns |  0.0433 ns |  11.83 |    0.36 | 0.0115 |     - |     - |      24 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |     20.3490 ns |  0.1764 ns |  0.1564 ns |  35.63 |    1.28 |      - |     - |     - |         - |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |     0 |     20.8918 ns |  0.3274 ns |  0.2734 ns |  36.69 |    1.54 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |      .NET 4.8 |      .NET 4.8 |     0 |     44.3539 ns |  0.2721 ns |  0.2273 ns |  77.87 |    2.52 |      - |     - |     - |         - |
|        Hyperlinq_For |      .NET 4.8 |      .NET 4.8 |     0 |     23.3676 ns |  0.0878 ns |  0.0778 ns |  40.92 |    1.40 |      - |     - |     - |         - |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |      0.5760 ns |  0.0081 ns |  0.0072 ns |   1.01 |    0.04 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |      0.5587 ns |  0.0163 ns |  0.0145 ns |   0.98 |    0.05 |      - |     - |     - |         - |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |     27.7300 ns |  0.1295 ns |  0.1081 ns |  48.69 |    1.64 |      - |     - |     - |         - |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     0 |      8.4365 ns |  0.0805 ns |  0.0714 ns |  14.77 |    0.53 | 0.0115 |     - |     - |      24 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |     21.4459 ns |  0.0962 ns |  0.0899 ns |  37.55 |    1.19 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |     0 |     21.1288 ns |  0.1202 ns |  0.1066 ns |  37.00 |    1.25 |      - |     - |     - |         - |
|    Hyperlinq_Foreach | .NET Core 3.1 | .NET Core 3.1 |     0 |     32.4611 ns |  0.1991 ns |  0.1862 ns |  56.83 |    1.92 |      - |     - |     - |         - |
|        Hyperlinq_For | .NET Core 3.1 | .NET Core 3.1 |     0 |     20.8929 ns |  0.0786 ns |  0.0657 ns |  36.68 |    1.17 |      - |     - |     - |         - |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |      0.5724 ns |  0.0076 ns |  0.0068 ns |   1.00 |    0.04 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |      0.2497 ns |  0.0061 ns |  0.0054 ns |   0.44 |    0.02 |      - |     - |     - |         - |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |     20.7110 ns |  0.1599 ns |  0.1495 ns |  36.26 |    1.06 |      - |     - |     - |         - |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     0 |      8.2509 ns |  0.0769 ns |  0.0642 ns |  14.48 |    0.39 | 0.0115 |     - |     - |      24 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |     15.0887 ns |  0.0842 ns |  0.0746 ns |  26.42 |    0.86 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |     0 |     15.6821 ns |  0.0713 ns |  0.0632 ns |  27.46 |    0.91 |      - |     - |     - |         - |
|    Hyperlinq_Foreach | .NET Core 5.0 | .NET Core 5.0 |     0 |     19.7530 ns |  0.0955 ns |  0.0797 ns |  34.68 |    1.15 |      - |     - |     - |         - |
|        Hyperlinq_For | .NET Core 5.0 | .NET Core 5.0 |     0 |      8.7988 ns |  0.0567 ns |  0.0503 ns |  15.41 |    0.51 |      - |     - |     - |         - |
|                      |               |               |       |                |            |            |        |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **1** |      **0.4943 ns** |  **0.0142 ns** |  **0.0126 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |     1 |      0.0452 ns |  0.0104 ns |  0.0093 ns |   0.09 |    0.02 |      - |     - |     - |         - |
|                 Linq |      .NET 4.8 |      .NET 4.8 |     1 |     38.9480 ns |  0.3012 ns |  0.2817 ns |  78.83 |    2.40 | 0.0268 |     - |     - |      56 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |     1 |      7.6007 ns |  0.0819 ns |  0.0766 ns |  15.39 |    0.52 | 0.0153 |     - |     - |      32 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |     1 |     23.8312 ns |  0.0595 ns |  0.0497 ns |  48.18 |    1.21 |      - |     - |     - |         - |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |     1 |     23.4568 ns |  0.1206 ns |  0.1069 ns |  47.48 |    1.28 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |      .NET 4.8 |      .NET 4.8 |     1 |     59.8263 ns |  0.2300 ns |  0.2039 ns | 121.11 |    3.26 |      - |     - |     - |         - |
|        Hyperlinq_For |      .NET 4.8 |      .NET 4.8 |     1 |     37.7646 ns |  0.1801 ns |  0.1684 ns |  76.48 |    1.89 |      - |     - |     - |         - |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |     1 |      0.3057 ns |  0.0135 ns |  0.0126 ns |   0.62 |    0.03 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     1 |      0.2909 ns |  0.0087 ns |  0.0068 ns |   0.59 |    0.02 |      - |     - |     - |         - |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |     1 |     50.2196 ns |  0.3612 ns |  0.3379 ns | 101.64 |    2.71 | 0.0229 |     - |     - |      48 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     1 |      8.9333 ns |  0.0924 ns |  0.0819 ns |  18.09 |    0.60 | 0.0153 |     - |     - |      32 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |     1 |     24.3516 ns |  0.0951 ns |  0.0889 ns |  49.31 |    1.26 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |     1 |     24.0323 ns |  0.2130 ns |  0.1992 ns |  48.63 |    1.55 |      - |     - |     - |         - |
|    Hyperlinq_Foreach | .NET Core 3.1 | .NET Core 3.1 |     1 |     35.4862 ns |  0.2309 ns |  0.1928 ns |  71.75 |    1.98 |      - |     - |     - |         - |
|        Hyperlinq_For | .NET Core 3.1 | .NET Core 3.1 |     1 |     25.7135 ns |  0.1536 ns |  0.1361 ns |  52.05 |    1.30 |      - |     - |     - |         - |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |     1 |      0.4439 ns |  0.0096 ns |  0.0089 ns |   0.90 |    0.03 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     1 |      0.0674 ns |  0.0071 ns |  0.0063 ns |   0.14 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |     1 |     45.0197 ns |  0.1986 ns |  0.1857 ns |  91.10 |    2.60 | 0.0229 |     - |     - |      48 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     1 |      8.8982 ns |  0.0576 ns |  0.0481 ns |  17.99 |    0.52 | 0.0153 |     - |     - |      32 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |     1 |     18.5520 ns |  0.1112 ns |  0.0986 ns |  37.55 |    0.91 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |     1 |     18.0799 ns |  0.0592 ns |  0.0525 ns |  36.60 |    0.89 |      - |     - |     - |         - |
|    Hyperlinq_Foreach | .NET Core 5.0 | .NET Core 5.0 |     1 |     22.9104 ns |  0.1204 ns |  0.1126 ns |  46.38 |    1.10 |      - |     - |     - |         - |
|        Hyperlinq_For | .NET Core 5.0 | .NET Core 5.0 |     1 |     13.6358 ns |  0.0542 ns |  0.0507 ns |  27.61 |    0.73 |      - |     - |     - |         - |
|                      |               |               |       |                |            |            |        |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |    **10** |      **6.6805 ns** |  **0.0381 ns** |  **0.0356 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |    10 |      3.0470 ns |  0.0410 ns |  0.0383 ns |   0.46 |    0.01 |      - |     - |     - |         - |
|                 Linq |      .NET 4.8 |      .NET 4.8 |    10 |    104.9139 ns |  0.5056 ns |  0.4222 ns |  15.71 |    0.12 | 0.0267 |     - |     - |      56 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |    10 |     30.5365 ns |  0.1694 ns |  0.1502 ns |   4.57 |    0.04 | 0.0306 |     - |     - |      64 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |    10 |     41.9150 ns |  0.2956 ns |  0.2469 ns |   6.28 |    0.05 |      - |     - |     - |         - |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |    10 |     35.9830 ns |  0.1789 ns |  0.1586 ns |   5.39 |    0.04 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |      .NET 4.8 |      .NET 4.8 |    10 |     78.1462 ns |  0.3456 ns |  0.2886 ns |  11.70 |    0.09 |      - |     - |     - |         - |
|        Hyperlinq_For |      .NET 4.8 |      .NET 4.8 |    10 |    185.4349 ns |  0.5422 ns |  0.5071 ns |  27.76 |    0.17 |      - |     - |     - |         - |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |    10 |      6.1904 ns |  0.0501 ns |  0.0418 ns |   0.93 |    0.01 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |    10 |      3.0997 ns |  0.0276 ns |  0.0258 ns |   0.46 |    0.00 |      - |     - |     - |         - |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |    10 |    115.7999 ns |  0.5645 ns |  0.4714 ns |  17.34 |    0.10 | 0.0229 |     - |     - |      48 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |    10 |     30.7819 ns |  0.2385 ns |  0.2114 ns |   4.61 |    0.04 | 0.0306 |     - |     - |      64 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |    10 |     43.0503 ns |  0.3162 ns |  0.2958 ns |   6.44 |    0.06 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |    10 |     36.4999 ns |  0.2280 ns |  0.1904 ns |   5.47 |    0.04 |      - |     - |     - |         - |
|    Hyperlinq_Foreach | .NET Core 3.1 | .NET Core 3.1 |    10 |     58.1190 ns |  0.2313 ns |  0.2050 ns |   8.70 |    0.06 |      - |     - |     - |         - |
|        Hyperlinq_For | .NET Core 3.1 | .NET Core 3.1 |    10 |     70.5603 ns |  0.3168 ns |  0.2963 ns |  10.56 |    0.08 |      - |     - |     - |         - |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |    10 |      6.2178 ns |  0.0902 ns |  0.0754 ns |   0.93 |    0.01 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |    10 |      2.9088 ns |  0.0202 ns |  0.0189 ns |   0.44 |    0.00 |      - |     - |     - |         - |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |    10 |    110.9913 ns |  0.9268 ns |  0.8669 ns |  16.61 |    0.15 | 0.0229 |     - |     - |      48 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |    10 |     33.0655 ns |  0.1918 ns |  0.1794 ns |   4.95 |    0.04 | 0.0306 |     - |     - |      64 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |    10 |     35.9273 ns |  0.1797 ns |  0.1593 ns |   5.38 |    0.03 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |    10 |     29.9734 ns |  0.0648 ns |  0.0506 ns |   4.49 |    0.03 |      - |     - |     - |         - |
|    Hyperlinq_Foreach | .NET Core 5.0 | .NET Core 5.0 |    10 |     43.5895 ns |  0.1993 ns |  0.1767 ns |   6.52 |    0.03 |      - |     - |     - |         - |
|        Hyperlinq_For | .NET Core 5.0 | .NET Core 5.0 |    10 |     55.7625 ns |  0.2831 ns |  0.2509 ns |   8.35 |    0.06 |      - |     - |     - |         - |
|                      |               |               |       |                |            |            |        |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |  **1000** |    **548.2017 ns** |  **4.3803 ns** |  **3.8830 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |  1000 |    406.2861 ns |  2.1001 ns |  1.7537 ns |   0.74 |    0.00 |      - |     - |     - |         - |
|                 Linq |      .NET 4.8 |      .NET 4.8 |  1000 |  6,002.2175 ns | 19.2393 ns | 17.9965 ns |  10.95 |    0.09 | 0.0229 |     - |     - |      56 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |  1000 |  2,685.2024 ns | 21.4736 ns | 19.0358 ns |   4.90 |    0.05 | 1.9226 |     - |     - |    4041 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |  1000 |  2,444.3247 ns | 11.9114 ns | 11.1420 ns |   4.46 |    0.04 |      - |     - |     - |         - |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |  1000 |  1,447.3952 ns |  5.0189 ns |  4.6947 ns |   2.64 |    0.02 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |      .NET 4.8 |      .NET 4.8 |  1000 |  3,284.5097 ns | 23.4746 ns | 20.8096 ns |   5.99 |    0.07 |      - |     - |     - |         - |
|        Hyperlinq_For |      .NET 4.8 |      .NET 4.8 |  1000 | 19,184.9139 ns | 64.9515 ns | 54.2375 ns |  34.95 |    0.22 |      - |     - |     - |         - |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |  1000 |    550.1698 ns |  2.3713 ns |  2.1021 ns |   1.00 |    0.01 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |  1000 |    406.8960 ns |  1.7637 ns |  1.5635 ns |   0.74 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |  1000 |  5,782.8236 ns | 23.3946 ns | 21.8833 ns |  10.55 |    0.07 | 0.0229 |     - |     - |      48 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |  1000 |  2,649.3207 ns | 18.5614 ns | 16.4542 ns |   4.83 |    0.05 | 1.9226 |     - |     - |    4024 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |  1000 |  2,443.0163 ns | 13.7315 ns | 12.1726 ns |   4.46 |    0.04 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |  1000 |  1,448.0825 ns |  6.4573 ns |  5.7242 ns |   2.64 |    0.02 |      - |     - |     - |         - |
|    Hyperlinq_Foreach | .NET Core 3.1 | .NET Core 3.1 |  1000 |  2,460.3920 ns | 13.7242 ns | 11.4603 ns |   4.48 |    0.03 |      - |     - |     - |         - |
|        Hyperlinq_For | .NET Core 3.1 | .NET Core 3.1 |  1000 |  4,871.1412 ns | 28.3767 ns | 26.5436 ns |   8.88 |    0.06 |      - |     - |     - |         - |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |  1000 |    546.4439 ns |  2.6973 ns |  2.5231 ns |   1.00 |    0.01 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |  1000 |    407.3511 ns |  2.7605 ns |  2.4471 ns |   0.74 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |  1000 |  5,445.9383 ns | 26.0913 ns | 23.1292 ns |   9.93 |    0.09 | 0.0229 |     - |     - |      48 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |  1000 |  2,643.6835 ns | 14.6511 ns | 12.9878 ns |   4.82 |    0.05 | 1.9226 |     - |     - |    4024 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |  1000 |  2,716.2794 ns | 28.8086 ns | 24.0565 ns |   4.95 |    0.04 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |  1000 |  1,435.6076 ns |  5.4590 ns |  5.1063 ns |   2.62 |    0.02 |      - |     - |     - |         - |
|    Hyperlinq_Foreach | .NET Core 5.0 | .NET Core 5.0 |  1000 |  2,460.7911 ns |  7.9974 ns |  7.0895 ns |   4.49 |    0.04 |      - |     - |     - |         - |
|        Hyperlinq_For | .NET Core 5.0 | .NET Core 5.0 |  1000 |  4,588.8236 ns | 26.6232 ns | 24.9034 ns |   8.37 |    0.06 |      - |     - |     - |         - |

## ArraySkipTakeSelect

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET 4.8      : .NET Framework 4.8 (4.8.4180.0), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT


```
|            Method |           Job |       Runtime | Skip | Count |           Mean |      Error |     StdDev |    Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------ |-------------- |-------------- |----- |------ |---------------:|-----------:|-----------:|---------:|--------:|-------:|------:|------:|----------:|
|           **ForLoop** |      **.NET 4.8** |      **.NET 4.8** | **1000** |     **0** |      **0.3384 ns** |  **0.0129 ns** |  **0.0115 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|       ForeachLoop |      .NET 4.8 |      .NET 4.8 | 1000 |     0 |  2,163.1279 ns | 11.2909 ns | 10.5615 ns | 6,399.64 |  231.69 | 0.0153 |     - |     - |      32 B |
|              Linq |      .NET 4.8 |      .NET 4.8 | 1000 |     0 |     65.2305 ns |  0.8739 ns |  0.7747 ns |   192.99 |    6.97 | 0.0918 |     - |     - |     193 B |
|        LinqFaster |      .NET 4.8 |      .NET 4.8 | 1000 |     0 |     26.2319 ns |  0.1590 ns |  0.1328 ns |    77.77 |    2.53 | 0.0115 |     - |     - |      24 B |
| Hyperlinq_Foreach |      .NET 4.8 |      .NET 4.8 | 1000 |     0 |     52.8034 ns |  0.2669 ns |  0.2496 ns |   156.16 |    5.20 |      - |     - |     - |         - |
|     Hyperlinq_For |      .NET 4.8 |      .NET 4.8 | 1000 |     0 |     31.7148 ns |  0.1884 ns |  0.1762 ns |    93.90 |    3.35 |      - |     - |     - |         - |
|           ForLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |     0 |      0.2710 ns |  0.0086 ns |  0.0076 ns |     0.80 |    0.04 |      - |     - |     - |         - |
|       ForeachLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |     0 |  2,434.7292 ns | 11.4239 ns | 10.1270 ns | 7,203.47 |  246.48 | 0.0153 |     - |     - |      32 B |
|              Linq | .NET Core 3.1 | .NET Core 3.1 | 1000 |     0 |     59.3307 ns |  0.4122 ns |  0.3654 ns |   175.54 |    6.01 | 0.0229 |     - |     - |      48 B |
|        LinqFaster | .NET Core 3.1 | .NET Core 3.1 | 1000 |     0 |      8.1201 ns |  0.0910 ns |  0.0807 ns |    24.02 |    0.83 | 0.0115 |     - |     - |      24 B |
| Hyperlinq_Foreach | .NET Core 3.1 | .NET Core 3.1 | 1000 |     0 |     39.8652 ns |  0.1562 ns |  0.1384 ns |   117.95 |    4.06 |      - |     - |     - |         - |
|     Hyperlinq_For | .NET Core 3.1 | .NET Core 3.1 | 1000 |     0 |     28.1004 ns |  0.1805 ns |  0.1688 ns |    83.12 |    2.93 |      - |     - |     - |         - |
|           ForLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |     0 |      0.3189 ns |  0.0173 ns |  0.0145 ns |     0.95 |    0.05 |      - |     - |     - |         - |
|       ForeachLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |     0 |  2,177.5233 ns | 11.1745 ns | 10.4526 ns | 6,442.47 |  210.32 | 0.0153 |     - |     - |      32 B |
|              Linq | .NET Core 5.0 | .NET Core 5.0 | 1000 |     0 |     61.4591 ns |  0.2572 ns |  0.2280 ns |   181.84 |    6.24 | 0.0229 |     - |     - |      48 B |
|        LinqFaster | .NET Core 5.0 | .NET Core 5.0 | 1000 |     0 |      8.2207 ns |  0.0749 ns |  0.0701 ns |    24.31 |    0.91 | 0.0115 |     - |     - |      24 B |
| Hyperlinq_Foreach | .NET Core 5.0 | .NET Core 5.0 | 1000 |     0 |     28.3690 ns |  0.2200 ns |  0.1951 ns |    83.93 |    2.78 |      - |     - |     - |         - |
|     Hyperlinq_For | .NET Core 5.0 | .NET Core 5.0 | 1000 |     0 |     16.7390 ns |  0.0767 ns |  0.0680 ns |    49.53 |    1.72 |      - |     - |     - |         - |
|                   |               |               |      |       |                |            |            |          |         |        |       |       |           |
|           **ForLoop** |      **.NET 4.8** |      **.NET 4.8** | **1000** |     **1** |      **0.4934 ns** |  **0.0186 ns** |  **0.0165 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|       ForeachLoop |      .NET 4.8 |      .NET 4.8 | 1000 |     1 |  2,177.4249 ns | 17.5258 ns | 16.3937 ns | 4,418.35 |  148.86 | 0.0153 |     - |     - |      32 B |
|              Linq |      .NET 4.8 |      .NET 4.8 | 1000 |     1 |  2,852.3650 ns |  9.7887 ns |  8.6774 ns | 5,787.18 |  198.63 | 0.1068 |     - |     - |     225 B |
|        LinqFaster |      .NET 4.8 |      .NET 4.8 | 1000 |     1 |     28.1183 ns |  0.1831 ns |  0.1529 ns |    57.26 |    1.73 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_Foreach |      .NET 4.8 |      .NET 4.8 | 1000 |     1 |     56.8137 ns |  0.1877 ns |  0.1664 ns |   115.27 |    4.07 |      - |     - |     - |         - |
|     Hyperlinq_For |      .NET 4.8 |      .NET 4.8 | 1000 |     1 |     45.5805 ns |  0.2503 ns |  0.2219 ns |    92.48 |    3.21 |      - |     - |     - |         - |
|           ForLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |     1 |      0.2639 ns |  0.0098 ns |  0.0087 ns |     0.54 |    0.03 |      - |     - |     - |         - |
|       ForeachLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |     1 |  2,449.0405 ns | 14.3614 ns | 13.4337 ns | 4,971.28 |  183.17 | 0.0153 |     - |     - |      32 B |
|              Linq | .NET Core 3.1 | .NET Core 3.1 | 1000 |     1 |    107.6098 ns |  1.4198 ns |  1.2586 ns |   218.30 |    6.77 | 0.0726 |     - |     - |     152 B |
|        LinqFaster | .NET Core 3.1 | .NET Core 3.1 | 1000 |     1 |     10.2962 ns |  0.1019 ns |  0.0904 ns |    20.89 |    0.81 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_Foreach | .NET Core 3.1 | .NET Core 3.1 | 1000 |     1 |     42.8803 ns |  0.1580 ns |  0.1478 ns |    87.01 |    2.96 |      - |     - |     - |         - |
|     Hyperlinq_For | .NET Core 3.1 | .NET Core 3.1 | 1000 |     1 |     33.2445 ns |  0.2384 ns |  0.1991 ns |    67.70 |    2.19 |      - |     - |     - |         - |
|           ForLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |     1 |      0.3195 ns |  0.0169 ns |  0.0150 ns |     0.65 |    0.04 |      - |     - |     - |         - |
|       ForeachLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |     1 |  2,174.4871 ns | 15.7461 ns | 14.7289 ns | 4,410.45 |  156.66 | 0.0153 |     - |     - |      32 B |
|              Linq | .NET Core 5.0 | .NET Core 5.0 | 1000 |     1 |     96.9234 ns |  0.9462 ns |  0.8388 ns |   196.65 |    6.88 | 0.0726 |     - |     - |     152 B |
|        LinqFaster | .NET Core 5.0 | .NET Core 5.0 | 1000 |     1 |     10.4945 ns |  0.0757 ns |  0.0671 ns |    21.29 |    0.80 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_Foreach | .NET Core 5.0 | .NET Core 5.0 | 1000 |     1 |     31.2607 ns |  0.1445 ns |  0.1207 ns |    63.66 |    1.94 |      - |     - |     - |         - |
|     Hyperlinq_For | .NET Core 5.0 | .NET Core 5.0 | 1000 |     1 |     22.3727 ns |  0.1614 ns |  0.1510 ns |    45.41 |    1.70 |      - |     - |     - |         - |
|                   |               |               |      |       |                |            |            |          |         |        |       |       |           |
|           **ForLoop** |      **.NET 4.8** |      **.NET 4.8** | **1000** |    **10** |      **6.3214 ns** |  **0.0484 ns** |  **0.0453 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|       ForeachLoop |      .NET 4.8 |      .NET 4.8 | 1000 |    10 |  2,209.0818 ns | 11.5289 ns | 10.7841 ns |   349.48 |    3.28 | 0.0153 |     - |     - |      32 B |
|              Linq |      .NET 4.8 |      .NET 4.8 | 1000 |    10 |  3,064.9359 ns | 11.5841 ns | 10.8358 ns |   484.87 |    3.50 | 0.1068 |     - |     - |     225 B |
|        LinqFaster |      .NET 4.8 |      .NET 4.8 | 1000 |    10 |     50.6320 ns |  0.3229 ns |  0.3020 ns |     8.01 |    0.09 | 0.0306 |     - |     - |      64 B |
| Hyperlinq_Foreach |      .NET 4.8 |      .NET 4.8 | 1000 |    10 |     87.6156 ns |  0.4482 ns |  0.3974 ns |    13.85 |    0.13 |      - |     - |     - |         - |
|     Hyperlinq_For |      .NET 4.8 |      .NET 4.8 | 1000 |    10 |    190.0047 ns |  0.9670 ns |  0.8572 ns |    30.04 |    0.24 |      - |     - |     - |         - |
|           ForLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |    10 |      5.1858 ns |  0.0346 ns |  0.0307 ns |     0.82 |    0.01 |      - |     - |     - |         - |
|       ForeachLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |    10 |  2,482.3868 ns | 15.3519 ns | 11.9858 ns |   392.29 |    2.99 | 0.0153 |     - |     - |      32 B |
|              Linq | .NET Core 3.1 | .NET Core 3.1 | 1000 |    10 |    203.7044 ns |  1.5559 ns |  1.2993 ns |    32.20 |    0.22 | 0.0725 |     - |     - |     152 B |
|        LinqFaster | .NET Core 3.1 | .NET Core 3.1 | 1000 |    10 |     32.1691 ns |  0.2046 ns |  0.1913 ns |     5.09 |    0.04 | 0.0306 |     - |     - |      64 B |
| Hyperlinq_Foreach | .NET Core 3.1 | .NET Core 3.1 | 1000 |    10 |     66.0535 ns |  0.2882 ns |  0.2696 ns |    10.45 |    0.07 |      - |     - |     - |         - |
|     Hyperlinq_For | .NET Core 3.1 | .NET Core 3.1 | 1000 |    10 |     77.3727 ns |  0.4552 ns |  0.3801 ns |    12.23 |    0.09 |      - |     - |     - |         - |
|           ForLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |    10 |      6.4219 ns |  0.0543 ns |  0.0508 ns |     1.02 |    0.01 |      - |     - |     - |         - |
|       ForeachLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |    10 |  2,490.7279 ns | 10.2567 ns |  8.5648 ns |   393.72 |    2.54 | 0.0153 |     - |     - |      32 B |
|              Linq | .NET Core 5.0 | .NET Core 5.0 | 1000 |    10 |    199.9138 ns |  1.5343 ns |  1.2812 ns |    31.60 |    0.29 | 0.0725 |     - |     - |     152 B |
|        LinqFaster | .NET Core 5.0 | .NET Core 5.0 | 1000 |    10 |     33.4428 ns |  0.2079 ns |  0.1736 ns |     5.29 |    0.05 | 0.0306 |     - |     - |      64 B |
| Hyperlinq_Foreach | .NET Core 5.0 | .NET Core 5.0 | 1000 |    10 |     51.5267 ns |  0.1554 ns |  0.1377 ns |     8.15 |    0.06 |      - |     - |     - |         - |
|     Hyperlinq_For | .NET Core 5.0 | .NET Core 5.0 | 1000 |    10 |     63.6836 ns |  0.4547 ns |  0.3797 ns |    10.07 |    0.11 |      - |     - |     - |         - |
|                   |               |               |      |       |                |            |            |          |         |        |       |       |           |
|           **ForLoop** |      **.NET 4.8** |      **.NET 4.8** | **1000** |  **1000** |    **552.9748 ns** |  **4.4739 ns** |  **3.9660 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|       ForeachLoop |      .NET 4.8 |      .NET 4.8 | 1000 |  1000 |  5,125.1975 ns | 18.6289 ns | 15.5560 ns |     9.26 |    0.06 | 0.0153 |     - |     - |      32 B |
|              Linq |      .NET 4.8 |      .NET 4.8 | 1000 |  1000 | 23,176.5548 ns | 93.4216 ns | 78.0113 ns |    41.89 |    0.34 | 0.0916 |     - |     - |     225 B |
|        LinqFaster |      .NET 4.8 |      .NET 4.8 | 1000 |  1000 |  2,705.1858 ns | 14.6330 ns | 12.2192 ns |     4.89 |    0.04 | 1.9226 |     - |     - |    4041 B |
| Hyperlinq_Foreach |      .NET 4.8 |      .NET 4.8 | 1000 |  1000 |  4,064.6581 ns | 19.4639 ns | 17.2543 ns |     7.35 |    0.06 |      - |     - |     - |         - |
|     Hyperlinq_For |      .NET 4.8 |      .NET 4.8 | 1000 |  1000 | 15,337.8076 ns | 81.4019 ns | 67.9742 ns |    27.72 |    0.26 |      - |     - |     - |         - |
|           ForLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |  1000 |    489.3703 ns |  2.9499 ns |  2.7594 ns |     0.89 |    0.01 |      - |     - |     - |         - |
|       ForeachLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |  1000 |  4,369.9197 ns | 17.9298 ns | 16.7716 ns |     7.90 |    0.06 | 0.0153 |     - |     - |      32 B |
|              Linq | .NET Core 3.1 | .NET Core 3.1 | 1000 |  1000 | 10,070.6034 ns | 70.6848 ns | 66.1186 ns |    18.23 |    0.15 | 0.0610 |     - |     - |     152 B |
|        LinqFaster | .NET Core 3.1 | .NET Core 3.1 | 1000 |  1000 |  2,674.4266 ns |  9.3967 ns |  8.3300 ns |     4.84 |    0.04 | 1.9226 |     - |     - |    4024 B |
| Hyperlinq_Foreach | .NET Core 3.1 | .NET Core 3.1 | 1000 |  1000 |  2,716.3864 ns | 13.1002 ns | 12.2539 ns |     4.91 |    0.03 |      - |     - |     - |         - |
|     Hyperlinq_For | .NET Core 3.1 | .NET Core 3.1 | 1000 |  1000 |  4,868.8956 ns | 30.4740 ns | 27.0144 ns |     8.81 |    0.08 |      - |     - |     - |         - |
|           ForLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |  1000 |    551.0507 ns |  2.7597 ns |  2.5815 ns |     1.00 |    0.01 |      - |     - |     - |         - |
|       ForeachLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |  1000 |  4,340.3832 ns | 14.8813 ns | 13.9200 ns |     7.85 |    0.07 | 0.0153 |     - |     - |      32 B |
|              Linq | .NET Core 5.0 | .NET Core 5.0 | 1000 |  1000 | 10,031.1509 ns | 49.2222 ns | 46.0425 ns |    18.15 |    0.13 | 0.0610 |     - |     - |     152 B |
|        LinqFaster | .NET Core 5.0 | .NET Core 5.0 | 1000 |  1000 |  2,391.4289 ns | 11.5784 ns |  9.6685 ns |     4.32 |    0.03 | 1.9226 |     - |     - |    4024 B |
| Hyperlinq_Foreach | .NET Core 5.0 | .NET Core 5.0 | 1000 |  1000 |  2,743.8130 ns | 10.2210 ns |  9.5607 ns |     4.96 |    0.05 |      - |     - |     - |         - |
|     Hyperlinq_For | .NET Core 5.0 | .NET Core 5.0 | 1000 |  1000 |  4,598.0343 ns | 23.1367 ns | 21.6421 ns |     8.32 |    0.08 |      - |     - |     - |         - |

## ArraySkipTakeWhere

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET 4.8      : .NET Framework 4.8 (4.8.4180.0), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT


```
|      Method |           Job |       Runtime | Skip | Count |           Mean |       Error |      StdDev |    Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |-------------- |-------------- |----- |------ |---------------:|------------:|------------:|---------:|--------:|-------:|------:|------:|----------:|
|     **ForLoop** |      **.NET 4.8** |      **.NET 4.8** | **1000** |     **0** |      **0.2487 ns** |   **0.0044 ns** |   **0.0039 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
| ForeachLoop |      .NET 4.8 |      .NET 4.8 | 1000 |     0 |  2,166.8536 ns |  10.7662 ns |  10.0707 ns | 8,711.61 |  143.50 | 0.0153 |     - |     - |      32 B |
|        Linq |      .NET 4.8 |      .NET 4.8 | 1000 |     0 |     66.4146 ns |   0.5220 ns |   0.4882 ns |   267.03 |    5.08 | 0.0880 |     - |     - |     185 B |
|  LinqFaster |      .NET 4.8 |      .NET 4.8 | 1000 |     0 |     28.3063 ns |   0.1932 ns |   0.1613 ns |   113.87 |    1.86 | 0.0114 |     - |     - |      24 B |
|   Hyperlinq |      .NET 4.8 |      .NET 4.8 | 1000 |     0 |     53.4397 ns |   0.1131 ns |   0.1058 ns |   214.90 |    3.29 |      - |     - |     - |         - |
|     ForLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |     0 |      0.2839 ns |   0.0144 ns |   0.0128 ns |     1.14 |    0.05 |      - |     - |     - |         - |
| ForeachLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |     0 |  2,441.7477 ns |  10.5816 ns |   9.8981 ns | 9,817.46 |  163.25 | 0.0153 |     - |     - |      32 B |
|        Linq | .NET Core 3.1 | .NET Core 3.1 | 1000 |     0 |     84.8100 ns |   0.4421 ns |   0.3919 ns |   341.08 |    5.17 | 0.0497 |     - |     - |     104 B |
|  LinqFaster | .NET Core 3.1 | .NET Core 3.1 | 1000 |     0 |     10.3516 ns |   0.1423 ns |   0.1331 ns |    41.62 |    0.87 | 0.0115 |     - |     - |      24 B |
|   Hyperlinq | .NET Core 3.1 | .NET Core 3.1 | 1000 |     0 |     40.3047 ns |   0.2618 ns |   0.2449 ns |   161.98 |    2.79 |      - |     - |     - |         - |
|     ForLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |     0 |      0.3233 ns |   0.0060 ns |   0.0053 ns |     1.30 |    0.04 |      - |     - |     - |         - |
| ForeachLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |     0 |  2,168.6841 ns |   8.6056 ns |   7.6287 ns | 8,721.71 |  129.88 | 0.0153 |     - |     - |      32 B |
|        Linq | .NET Core 5.0 | .NET Core 5.0 | 1000 |     0 |     78.0443 ns |   0.6908 ns |   0.6124 ns |   313.87 |    5.57 | 0.0497 |     - |     - |     104 B |
|  LinqFaster | .NET Core 5.0 | .NET Core 5.0 | 1000 |     0 |     10.2757 ns |   0.0821 ns |   0.0768 ns |    41.36 |    0.77 | 0.0115 |     - |     - |      24 B |
|   Hyperlinq | .NET Core 5.0 | .NET Core 5.0 | 1000 |     0 |     28.3976 ns |   0.1799 ns |   0.1502 ns |   114.23 |    1.91 |      - |     - |     - |         - |
|             |               |               |      |       |                |             |             |          |         |        |       |       |           |
|     **ForLoop** |      **.NET 4.8** |      **.NET 4.8** | **1000** |     **1** |      **0.5775 ns** |   **0.0126 ns** |   **0.0112 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
| ForeachLoop |      .NET 4.8 |      .NET 4.8 | 1000 |     1 |  2,180.1552 ns |   9.8693 ns |   8.7489 ns | 3,776.18 |   70.64 | 0.0153 |     - |     - |      32 B |
|        Linq |      .NET 4.8 |      .NET 4.8 | 1000 |     1 |  2,853.5898 ns |   9.6233 ns |   8.5308 ns | 4,942.63 |   92.47 | 0.1030 |     - |     - |     217 B |
|  LinqFaster |      .NET 4.8 |      .NET 4.8 | 1000 |     1 |     30.5376 ns |   0.2319 ns |   0.2056 ns |    52.89 |    0.99 | 0.0153 |     - |     - |      32 B |
|   Hyperlinq |      .NET 4.8 |      .NET 4.8 | 1000 |     1 |     58.7936 ns |   0.2119 ns |   0.1878 ns |   101.84 |    1.94 |      - |     - |     - |         - |
|     ForLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |     1 |      0.2888 ns |   0.0077 ns |   0.0068 ns |     0.50 |    0.02 |      - |     - |     - |         - |
| ForeachLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |     1 |  2,434.4042 ns |  13.0694 ns |  12.2251 ns | 4,215.62 |   91.19 | 0.0153 |     - |     - |      32 B |
|        Linq | .NET Core 3.1 | .NET Core 3.1 | 1000 |     1 |    120.3569 ns |   0.9979 ns |   0.8846 ns |   208.46 |    3.83 | 0.0725 |     - |     - |     152 B |
|  LinqFaster | .NET Core 3.1 | .NET Core 3.1 | 1000 |     1 |     12.1966 ns |   0.2366 ns |   0.1975 ns |    21.07 |    0.47 | 0.0153 |     - |     - |      32 B |
|   Hyperlinq | .NET Core 3.1 | .NET Core 3.1 | 1000 |     1 |     45.7023 ns |   0.6205 ns |   0.5181 ns |    78.96 |    1.53 |      - |     - |     - |         - |
|     ForLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |     1 |      0.2971 ns |   0.0242 ns |   0.0215 ns |     0.51 |    0.04 |      - |     - |     - |         - |
| ForeachLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |     1 |  2,145.6266 ns |  16.4677 ns |  15.4039 ns | 3,716.38 |   83.88 | 0.0153 |     - |     - |      32 B |
|        Linq | .NET Core 5.0 | .NET Core 5.0 | 1000 |     1 |    111.2587 ns |   0.7030 ns |   0.5871 ns |   192.23 |    3.26 | 0.0726 |     - |     - |     152 B |
|  LinqFaster | .NET Core 5.0 | .NET Core 5.0 | 1000 |     1 |     11.9042 ns |   0.0554 ns |   0.0491 ns |    20.62 |    0.45 | 0.0153 |     - |     - |      32 B |
|   Hyperlinq | .NET Core 5.0 | .NET Core 5.0 | 1000 |     1 |     32.6970 ns |   0.1632 ns |   0.1527 ns |    56.64 |    1.10 |      - |     - |     - |         - |
|             |               |               |      |       |                |             |             |          |         |        |       |       |           |
|     **ForLoop** |      **.NET 4.8** |      **.NET 4.8** | **1000** |    **10** |      **7.1391 ns** |   **0.0498 ns** |   **0.0416 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
| ForeachLoop |      .NET 4.8 |      .NET 4.8 | 1000 |    10 |  2,171.9135 ns |  28.2113 ns |  25.0086 ns |   304.53 |    3.47 | 0.0153 |     - |     - |      32 B |
|        Linq |      .NET 4.8 |      .NET 4.8 | 1000 |    10 |  2,969.8311 ns |  22.7561 ns |  21.2861 ns |   416.02 |    3.92 | 0.1030 |     - |     - |     217 B |
|  LinqFaster |      .NET 4.8 |      .NET 4.8 | 1000 |    10 |     75.0168 ns |   0.4684 ns |   0.4152 ns |    10.51 |    0.08 | 0.0535 |     - |     - |     112 B |
|   Hyperlinq |      .NET 4.8 |      .NET 4.8 | 1000 |    10 |     88.7728 ns |   0.4956 ns |   0.4394 ns |    12.43 |    0.07 |      - |     - |     - |         - |
|     ForLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |    10 |      6.9611 ns |   0.0599 ns |   0.0560 ns |     0.98 |    0.01 |      - |     - |     - |         - |
| ForeachLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |    10 |  2,420.1149 ns |  20.5316 ns |  17.1448 ns |   339.00 |    3.18 | 0.0153 |     - |     - |      32 B |
|        Linq | .NET Core 3.1 | .NET Core 3.1 | 1000 |    10 |    241.9079 ns |   1.5128 ns |   1.4151 ns |    33.87 |    0.32 | 0.0725 |     - |     - |     152 B |
|  LinqFaster | .NET Core 3.1 | .NET Core 3.1 | 1000 |    10 |     52.0945 ns |   0.5127 ns |   0.4796 ns |     7.28 |    0.07 | 0.0535 |     - |     - |     112 B |
|   Hyperlinq | .NET Core 3.1 | .NET Core 3.1 | 1000 |    10 |     70.6640 ns |   0.7992 ns |   0.7085 ns |     9.90 |    0.12 |      - |     - |     - |         - |
|     ForLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |    10 |      7.0302 ns |   0.0405 ns |   0.0379 ns |     0.98 |    0.01 |      - |     - |     - |         - |
| ForeachLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |    10 |  2,154.4966 ns |  14.2100 ns |  13.2920 ns |   301.51 |    2.41 | 0.0153 |     - |     - |      32 B |
|        Linq | .NET Core 5.0 | .NET Core 5.0 | 1000 |    10 |    240.4614 ns |   1.9441 ns |   1.8185 ns |    33.67 |    0.33 | 0.0725 |     - |     - |     152 B |
|  LinqFaster | .NET Core 5.0 | .NET Core 5.0 | 1000 |    10 |     46.5150 ns |   0.2666 ns |   0.2081 ns |     6.51 |    0.05 | 0.0535 |     - |     - |     112 B |
|   Hyperlinq | .NET Core 5.0 | .NET Core 5.0 | 1000 |    10 |     55.9119 ns |   0.2473 ns |   0.2314 ns |     7.83 |    0.06 |      - |     - |     - |         - |
|             |               |               |      |       |                |             |             |          |         |        |       |       |           |
|     **ForLoop** |      **.NET 4.8** |      **.NET 4.8** | **1000** |  **1000** |    **739.1148 ns** |   **3.8518 ns** |   **3.0072 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
| ForeachLoop |      .NET 4.8 |      .NET 4.8 | 1000 |  1000 |  5,777.3874 ns |  42.9679 ns |  38.0899 ns |     7.81 |    0.06 | 0.0153 |     - |     - |      32 B |
|        Linq |      .NET 4.8 |      .NET 4.8 | 1000 |  1000 | 21,376.1739 ns | 166.8196 ns | 156.0432 ns |    28.92 |    0.28 | 0.0916 |     - |     - |     217 B |
|  LinqFaster |      .NET 4.8 |      .NET 4.8 | 1000 |  1000 |  3,694.9801 ns |  33.1248 ns |  29.3642 ns |     5.00 |    0.03 | 2.8877 |     - |     - |    6067 B |
|   Hyperlinq |      .NET 4.8 |      .NET 4.8 | 1000 |  1000 |  4,340.9347 ns |  61.4198 ns |  57.4521 ns |     5.86 |    0.08 |      - |     - |     - |         - |
|     ForLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |  1000 |    579.9588 ns |   2.3104 ns |   2.1611 ns |     0.78 |    0.00 |      - |     - |     - |         - |
| ForeachLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |  1000 |  4,904.3875 ns |  21.2945 ns |  19.9189 ns |     6.63 |    0.02 | 0.0153 |     - |     - |      32 B |
|        Linq | .NET Core 3.1 | .NET Core 3.1 | 1000 |  1000 | 12,543.3458 ns |  96.3234 ns |  75.2030 ns |    16.97 |    0.12 | 0.0610 |     - |     - |     152 B |
|  LinqFaster | .NET Core 3.1 | .NET Core 3.1 | 1000 |  1000 |  2,797.7164 ns |  12.2387 ns |  10.2199 ns |     3.79 |    0.02 | 2.8877 |     - |     - |    6048 B |
|   Hyperlinq | .NET Core 3.1 | .NET Core 3.1 | 1000 |  1000 |  3,267.6019 ns |  27.3234 ns |  25.5584 ns |     4.42 |    0.03 |      - |     - |     - |         - |
|     ForLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |  1000 |    729.0273 ns |   4.0339 ns |   3.5760 ns |     0.99 |    0.01 |      - |     - |     - |         - |
| ForeachLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |  1000 |  5,153.4521 ns |  29.5549 ns |  27.6456 ns |     6.98 |    0.04 | 0.0153 |     - |     - |      32 B |
|        Linq | .NET Core 5.0 | .NET Core 5.0 | 1000 |  1000 | 13,306.9781 ns |  44.2922 ns |  39.2639 ns |    18.01 |    0.10 | 0.0610 |     - |     - |     152 B |
|  LinqFaster | .NET Core 5.0 | .NET Core 5.0 | 1000 |  1000 |  3,083.0974 ns |  21.5024 ns |  20.1134 ns |     4.18 |    0.03 | 2.8877 |     - |     - |    6048 B |
|   Hyperlinq | .NET Core 5.0 | .NET Core 5.0 | 1000 |  1000 |  3,389.6737 ns |  20.5412 ns |  18.2093 ns |     4.59 |    0.02 |      - |     - |     - |         - |

## ArrayWhere

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET 4.8      : .NET Framework 4.8 (4.8.4180.0), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT


```
|               Method |           Job |       Runtime | Count |          Mean |      Error |     StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |-------------- |-------------- |------ |--------------:|-----------:|-----------:|-------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **0** |     **0.3280 ns** |  **0.0100 ns** |  **0.0089 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |     0 |     0.2636 ns |  0.0068 ns |  0.0064 ns |   0.80 |    0.03 |      - |     - |     - |         - |
|                 Linq |      .NET 4.8 |      .NET 4.8 |     0 |    31.5560 ns |  0.1420 ns |  0.1259 ns |  96.28 |    2.81 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |     0 |     7.8254 ns |  0.0537 ns |  0.0502 ns |  23.87 |    0.69 | 0.0115 |     - |     - |      24 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |    20.7496 ns |  0.0515 ns |  0.0457 ns |  63.31 |    1.73 |      - |     - |     - |         - |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |     0 |    20.4298 ns |  0.1009 ns |  0.0842 ns |  62.32 |    1.78 |      - |     - |     - |         - |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |     0 |    44.6041 ns |  0.1943 ns |  0.1722 ns | 136.08 |    3.54 |      - |     - |     - |         - |
|      Hyperlinq_Local |      .NET 4.8 |      .NET 4.8 |     0 |    50.6582 ns |  0.2115 ns |  0.1875 ns | 154.56 |    4.12 | 0.0306 |     - |     - |      64 B |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |     0.5439 ns |  0.0130 ns |  0.0122 ns |   1.66 |    0.05 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |     0.5534 ns |  0.0090 ns |  0.0080 ns |   1.69 |    0.05 |      - |     - |     - |         - |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |    15.6590 ns |  0.0896 ns |  0.0795 ns |  47.77 |    1.26 |      - |     - |     - |         - |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     0 |     9.7194 ns |  0.0909 ns |  0.0806 ns |  29.65 |    0.75 | 0.0115 |     - |     - |      24 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |    20.8800 ns |  0.0800 ns |  0.0748 ns |  63.73 |    1.76 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |     0 |    20.7783 ns |  0.1272 ns |  0.1062 ns |  63.38 |    1.61 |      - |     - |     - |         - |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |     0 |    35.2415 ns |  0.1523 ns |  0.1272 ns | 107.50 |    2.97 |      - |     - |     - |         - |
|      Hyperlinq_Local | .NET Core 3.1 | .NET Core 3.1 |     0 |    38.8910 ns |  0.3374 ns |  0.2991 ns | 118.65 |    2.97 | 0.0306 |     - |     - |      64 B |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |     0.2863 ns |  0.0091 ns |  0.0085 ns |   0.87 |    0.04 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |     0.2697 ns |  0.0063 ns |  0.0056 ns |   0.82 |    0.03 |      - |     - |     - |         - |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |    13.8394 ns |  0.0907 ns |  0.0804 ns |  42.23 |    1.25 |      - |     - |     - |         - |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     0 |     9.6237 ns |  0.1190 ns |  0.1054 ns |  29.36 |    0.90 | 0.0115 |     - |     - |      24 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |    15.1519 ns |  0.0827 ns |  0.0774 ns |  46.24 |    1.29 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |     0 |    15.6938 ns |  0.0666 ns |  0.0623 ns |  47.86 |    1.19 |      - |     - |     - |         - |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |     0 |    20.2788 ns |  0.1180 ns |  0.1103 ns |  61.88 |    1.79 |      - |     - |     - |         - |
|      Hyperlinq_Local | .NET Core 5.0 | .NET Core 5.0 |     0 |    25.1008 ns |  0.1102 ns |  0.0977 ns |  76.58 |    2.14 | 0.0306 |     - |     - |      64 B |
|                      |               |               |       |               |            |            |        |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **1** |     **0.4913 ns** |  **0.0115 ns** |  **0.0107 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |     1 |     0.1625 ns |  0.0092 ns |  0.0086 ns |   0.33 |    0.02 |      - |     - |     - |         - |
|                 Linq |      .NET 4.8 |      .NET 4.8 |     1 |    37.0991 ns |  0.1995 ns |  0.1866 ns |  75.54 |    1.71 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |     1 |    10.0029 ns |  0.0551 ns |  0.0489 ns |  20.38 |    0.51 | 0.0153 |     - |     - |      32 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |     1 |    25.0781 ns |  0.1075 ns |  0.0839 ns |  50.96 |    1.25 |      - |     - |     - |         - |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |     1 |    23.6419 ns |  0.0995 ns |  0.0930 ns |  48.14 |    1.02 |      - |     - |     - |         - |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |     1 |    50.5252 ns |  0.2161 ns |  0.1915 ns | 102.95 |    2.49 |      - |     - |     - |         - |
|      Hyperlinq_Local |      .NET 4.8 |      .NET 4.8 |     1 |    58.7918 ns |  0.3869 ns |  0.3430 ns | 119.79 |    2.66 | 0.0305 |     - |     - |      64 B |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |     1 |     0.3562 ns |  0.0161 ns |  0.0135 ns |   0.72 |    0.03 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     1 |     0.3254 ns |  0.0091 ns |  0.0085 ns |   0.66 |    0.02 |      - |     - |     - |         - |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |     1 |    39.1570 ns |  0.2919 ns |  0.2438 ns |  79.62 |    1.99 | 0.0229 |     - |     - |      48 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     1 |    11.2067 ns |  0.0571 ns |  0.0534 ns |  22.82 |    0.51 | 0.0153 |     - |     - |      32 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |     1 |    25.3125 ns |  0.0747 ns |  0.0662 ns |  51.58 |    1.22 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |     1 |    23.6571 ns |  0.1016 ns |  0.0950 ns |  48.17 |    1.10 |      - |     - |     - |         - |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |     1 |    39.1850 ns |  0.1214 ns |  0.1135 ns |  79.79 |    1.59 |      - |     - |     - |         - |
|      Hyperlinq_Local | .NET Core 3.1 | .NET Core 3.1 |     1 |    45.1227 ns |  0.4130 ns |  0.3661 ns |  91.93 |    2.01 | 0.0306 |     - |     - |      64 B |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |     1 |     0.3685 ns |  0.0095 ns |  0.0088 ns |   0.75 |    0.01 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     1 |     0.1493 ns |  0.0086 ns |  0.0072 ns |   0.30 |    0.02 |      - |     - |     - |         - |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |     1 |    44.0078 ns |  0.3720 ns |  0.3298 ns |  89.66 |    1.93 | 0.0229 |     - |     - |      48 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     1 |    10.7569 ns |  0.0701 ns |  0.0621 ns |  21.92 |    0.51 | 0.0153 |     - |     - |      32 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |     1 |    18.9433 ns |  0.0586 ns |  0.0490 ns |  38.52 |    0.90 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |     1 |    18.8633 ns |  0.1001 ns |  0.0835 ns |  38.36 |    0.90 |      - |     - |     - |         - |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |     1 |    25.5244 ns |  0.0731 ns |  0.0648 ns |  52.01 |    1.15 |      - |     - |     - |         - |
|      Hyperlinq_Local | .NET Core 5.0 | .NET Core 5.0 |     1 |    31.3105 ns |  0.2042 ns |  0.1910 ns |  63.75 |    1.46 | 0.0306 |     - |     - |      64 B |
|                      |               |               |       |               |            |            |        |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |    **10** |     **8.0053 ns** |  **0.0446 ns** |  **0.0417 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |    10 |     6.6513 ns |  0.0467 ns |  0.0437 ns |   0.83 |    0.01 |      - |     - |     - |         - |
|                 Linq |      .NET 4.8 |      .NET 4.8 |    10 |    71.5673 ns |  0.3709 ns |  0.3469 ns |   8.94 |    0.06 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |    10 |    47.7745 ns |  0.2060 ns |  0.1721 ns |   5.97 |    0.05 | 0.0535 |     - |     - |     112 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |    10 |    46.9074 ns |  0.2093 ns |  0.1855 ns |   5.86 |    0.05 |      - |     - |     - |         - |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |    10 |    37.5068 ns |  0.1533 ns |  0.1359 ns |   4.68 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |    10 |    85.8656 ns |  0.6391 ns |  0.5666 ns |  10.72 |    0.10 |      - |     - |     - |         - |
|      Hyperlinq_Local |      .NET 4.8 |      .NET 4.8 |    10 |   106.0771 ns |  2.1004 ns |  2.0629 ns |  13.26 |    0.32 | 0.0305 |     - |     - |      64 B |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |    10 |     6.4834 ns |  0.0449 ns |  0.0420 ns |   0.81 |    0.01 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |    10 |     7.0019 ns |  0.0549 ns |  0.0513 ns |   0.87 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |    10 |    80.8932 ns |  0.3507 ns |  0.3109 ns |  10.10 |    0.08 | 0.0229 |     - |     - |      48 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |    10 |    49.8059 ns |  0.7293 ns |  0.6822 ns |   6.22 |    0.09 | 0.0535 |     - |     - |     112 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |    10 |    48.0358 ns |  0.2894 ns |  0.2416 ns |   6.00 |    0.04 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |    10 |    37.3726 ns |  0.2674 ns |  0.2370 ns |   4.67 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |    10 |    65.2403 ns |  0.4261 ns |  0.3986 ns |   8.15 |    0.08 |      - |     - |     - |         - |
|      Hyperlinq_Local | .NET Core 3.1 | .NET Core 3.1 |    10 |    75.8068 ns |  0.5038 ns |  0.4466 ns |   9.47 |    0.08 | 0.0305 |     - |     - |      64 B |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |    10 |     7.0136 ns |  0.0425 ns |  0.0355 ns |   0.88 |    0.01 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |    10 |     6.6372 ns |  0.0385 ns |  0.0342 ns |   0.83 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |    10 |    79.2403 ns |  0.4416 ns |  0.3687 ns |   9.89 |    0.08 | 0.0229 |     - |     - |      48 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |    10 |    47.0261 ns |  0.3248 ns |  0.2712 ns |   5.87 |    0.05 | 0.0535 |     - |     - |     112 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |    10 |    54.3181 ns |  0.1829 ns |  0.1710 ns |   6.79 |    0.04 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |    10 |    32.7513 ns |  0.1967 ns |  0.1840 ns |   4.09 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |    10 |    49.5565 ns |  0.2429 ns |  0.2272 ns |   6.19 |    0.04 |      - |     - |     - |         - |
|      Hyperlinq_Local | .NET Core 5.0 | .NET Core 5.0 |    10 |    59.1810 ns |  0.3494 ns |  0.3268 ns |   7.39 |    0.06 | 0.0305 |     - |     - |      64 B |
|                      |               |               |       |               |            |            |        |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |  **1000** |   **789.5097 ns** |  **3.1221 ns** |  **2.7676 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |  1000 |   734.7882 ns |  2.4218 ns |  2.1468 ns |   0.93 |    0.00 |      - |     - |     - |         - |
|                 Linq |      .NET 4.8 |      .NET 4.8 |  1000 | 4,102.6064 ns | 21.6329 ns | 19.1770 ns |   5.20 |    0.03 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |  1000 | 3,034.2619 ns | 17.6343 ns | 15.6324 ns |   3.84 |    0.03 | 2.8877 |     - |     - |    6067 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |  1000 | 3,307.0373 ns | 11.2437 ns | 10.5173 ns |   4.19 |    0.02 |      - |     - |     - |         - |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |  1000 | 1,637.9258 ns |  6.3981 ns |  5.6717 ns |   2.07 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |  1000 | 4,642.3563 ns | 12.9265 ns | 10.7942 ns |   5.88 |    0.02 |      - |     - |     - |         - |
|      Hyperlinq_Local |      .NET 4.8 |      .NET 4.8 |  1000 | 5,280.9203 ns | 98.7499 ns | 96.9856 ns |   6.68 |    0.13 | 0.0305 |     - |     - |      64 B |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |  1000 |   597.6758 ns |  2.6677 ns |  2.4954 ns |   0.76 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |  1000 |   733.1557 ns |  2.5691 ns |  2.1453 ns |   0.93 |    0.00 |      - |     - |     - |         - |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |  1000 | 4,240.1975 ns | 22.8065 ns | 20.2173 ns |   5.37 |    0.03 | 0.0229 |     - |     - |      48 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |  1000 | 2,907.7748 ns | 19.7193 ns | 17.4807 ns |   3.68 |    0.03 | 2.8877 |     - |     - |    6048 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |  1000 | 3,105.7152 ns | 10.9073 ns |  9.6691 ns |   3.93 |    0.01 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |  1000 | 1,481.2432 ns |  6.7877 ns |  6.3492 ns |   1.88 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |  1000 | 3,328.4601 ns | 17.8011 ns | 15.7802 ns |   4.22 |    0.02 |      - |     - |     - |         - |
|      Hyperlinq_Local | .NET Core 3.1 | .NET Core 3.1 |  1000 | 3,823.5907 ns | 18.0008 ns | 16.8380 ns |   4.85 |    0.03 | 0.0305 |     - |     - |      64 B |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |  1000 |   741.5847 ns |  2.5432 ns |  2.2545 ns |   0.94 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |  1000 |   734.4216 ns |  2.9941 ns |  2.8007 ns |   0.93 |    0.00 |      - |     - |     - |         - |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |  1000 | 4,250.6193 ns | 23.2209 ns | 21.7209 ns |   5.38 |    0.03 | 0.0229 |     - |     - |      48 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |  1000 | 2,920.4275 ns | 20.4969 ns | 17.1159 ns |   3.70 |    0.03 | 2.8877 |     - |     - |    6048 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |  1000 | 3,225.6909 ns | 15.0691 ns | 12.5834 ns |   4.09 |    0.02 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |  1000 | 1,467.5820 ns |  9.8376 ns |  8.7208 ns |   1.86 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |  1000 | 3,495.4111 ns | 15.3782 ns | 13.6324 ns |   4.43 |    0.02 |      - |     - |     - |         - |
|      Hyperlinq_Local | .NET Core 5.0 | .NET Core 5.0 |  1000 | 3,729.8867 ns | 14.4127 ns | 12.0353 ns |   4.72 |    0.02 | 0.0305 |     - |     - |      64 B |

## ArrayWhereCount

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET 4.8      : .NET Framework 4.8 (4.8.4180.0), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT


```
|               Method |           Job |       Runtime | Count |          Mean |       Error |      StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |-------------- |-------------- |------ |--------------:|------------:|------------:|-------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **0** |     **0.2589 ns** |   **0.0094 ns** |   **0.0083 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |     0 |     0.2907 ns |   0.0071 ns |   0.0063 ns |   1.12 |    0.03 |      - |     - |     - |         - |
|                 Linq |      .NET 4.8 |      .NET 4.8 |     0 |    13.9359 ns |   0.1287 ns |   0.1075 ns |  54.07 |    1.71 |      - |     - |     - |         - |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |     0 |     2.0108 ns |   0.0139 ns |   0.0116 ns |   7.80 |    0.26 |      - |     - |     - |         - |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |    33.4878 ns |   0.1938 ns |   0.1813 ns | 129.49 |    4.15 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |     0 |    33.2743 ns |   0.1900 ns |   0.1777 ns | 128.76 |    4.45 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |     0 |    29.3519 ns |   0.1408 ns |   0.1248 ns | 113.49 |    3.65 |      - |     - |     - |         - |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |     0.5266 ns |   0.0051 ns |   0.0045 ns |   2.04 |    0.07 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |     0.5644 ns |   0.0115 ns |   0.0107 ns |   2.18 |    0.09 |      - |     - |     - |         - |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |     8.2058 ns |   0.0463 ns |   0.0433 ns |  31.73 |    1.07 |      - |     - |     - |         - |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     0 |     1.8897 ns |   0.0127 ns |   0.0112 ns |   7.31 |    0.25 |      - |     - |     - |         - |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |    25.3892 ns |   0.1396 ns |   0.1237 ns |  98.17 |    3.42 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |     0 |    24.8279 ns |   0.1429 ns |   0.1267 ns |  96.01 |    3.50 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |     0 |    25.4855 ns |   0.1985 ns |   0.1760 ns |  98.54 |    3.37 |      - |     - |     - |         - |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |     0.3013 ns |   0.0095 ns |   0.0084 ns |   1.16 |    0.05 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |     0.2362 ns |   0.0053 ns |   0.0044 ns |   0.92 |    0.04 |      - |     - |     - |         - |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |     8.0852 ns |   0.0703 ns |   0.0623 ns |  31.27 |    1.15 |      - |     - |     - |         - |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     0 |     2.0993 ns |   0.0184 ns |   0.0154 ns |   8.14 |    0.26 |      - |     - |     - |         - |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |    18.3155 ns |   0.1255 ns |   0.1113 ns |  70.82 |    2.33 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |     0 |    21.6505 ns |   0.1141 ns |   0.1068 ns |  83.70 |    2.83 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |     0 |    13.4517 ns |   0.0801 ns |   0.0710 ns |  52.01 |    1.67 |      - |     - |     - |         - |
|                      |               |               |       |               |             |             |        |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **1** |     **0.4667 ns** |   **0.0128 ns** |   **0.0114 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |     1 |     0.3239 ns |   0.0098 ns |   0.0092 ns |   0.70 |    0.03 |      - |     - |     - |         - |
|                 Linq |      .NET 4.8 |      .NET 4.8 |     1 |    18.2678 ns |   0.0733 ns |   0.0612 ns |  39.15 |    0.96 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |     1 |     3.3415 ns |   0.0321 ns |   0.0285 ns |   7.16 |    0.15 |      - |     - |     - |         - |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |     1 |    36.0615 ns |   0.1699 ns |   0.1506 ns |  77.31 |    1.84 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |     1 |    33.9756 ns |   0.1598 ns |   0.1334 ns |  72.82 |    1.82 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |     1 |    31.2081 ns |   0.1294 ns |   0.1147 ns |  66.90 |    1.52 |      - |     - |     - |         - |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |     1 |     0.3665 ns |   0.0189 ns |   0.0158 ns |   0.79 |    0.03 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     1 |     0.3172 ns |   0.0122 ns |   0.0102 ns |   0.68 |    0.03 |      - |     - |     - |         - |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |     1 |    18.3956 ns |   0.1149 ns |   0.1075 ns |  39.44 |    1.02 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     1 |     3.3645 ns |   0.0139 ns |   0.0109 ns |   7.23 |    0.20 |      - |     - |     - |         - |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |     1 |    28.7415 ns |   0.1467 ns |   0.1372 ns |  61.61 |    1.52 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |     1 |    27.7665 ns |   0.2180 ns |   0.1933 ns |  59.52 |    1.44 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |     1 |    27.0500 ns |   0.0847 ns |   0.0751 ns |  57.99 |    1.41 |      - |     - |     - |         - |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |     1 |     0.3631 ns |   0.0127 ns |   0.0112 ns |   0.78 |    0.03 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     1 |     0.1120 ns |   0.0067 ns |   0.0059 ns |   0.24 |    0.02 |      - |     - |     - |         - |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |     1 |    18.5279 ns |   0.0710 ns |   0.0664 ns |  39.72 |    0.93 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     1 |     3.0198 ns |   0.0216 ns |   0.0192 ns |   6.47 |    0.17 |      - |     - |     - |         - |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |     1 |    22.7183 ns |   0.1498 ns |   0.1402 ns |  48.71 |    1.34 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |     1 |    21.6188 ns |   0.1242 ns |   0.1101 ns |  46.34 |    1.08 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |     1 |    14.9829 ns |   0.0640 ns |   0.0599 ns |  32.10 |    0.82 |      - |     - |     - |         - |
|                      |               |               |       |               |             |             |        |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |    **10** |     **7.0677 ns** |   **0.0770 ns** |   **0.0720 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |    10 |     6.3084 ns |   0.0430 ns |   0.0381 ns |   0.89 |    0.01 |      - |     - |     - |         - |
|                 Linq |      .NET 4.8 |      .NET 4.8 |    10 |    75.6742 ns |   0.3079 ns |   0.2880 ns |  10.71 |    0.10 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |    10 |    21.8826 ns |   0.0991 ns |   0.0828 ns |   3.09 |    0.04 |      - |     - |     - |         - |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |    10 |    64.3073 ns |   0.3397 ns |   0.3011 ns |   9.10 |    0.12 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |    10 |    48.1298 ns |   0.2089 ns |   0.1852 ns |   6.81 |    0.06 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |    10 |    49.5801 ns |   0.1875 ns |   0.1754 ns |   7.02 |    0.07 |      - |     - |     - |         - |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |    10 |     6.4360 ns |   0.0514 ns |   0.0481 ns |   0.91 |    0.01 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |    10 |     6.7229 ns |   0.0457 ns |   0.0382 ns |   0.95 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |    10 |    70.9560 ns |   0.3143 ns |   0.2940 ns |  10.04 |    0.09 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |    10 |    23.2510 ns |   0.1475 ns |   0.1308 ns |   3.29 |    0.03 |      - |     - |     - |         - |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |    10 |    54.9490 ns |   0.2262 ns |   0.2005 ns |   7.78 |    0.09 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |    10 |    40.6821 ns |   0.2813 ns |   0.2493 ns |   5.76 |    0.08 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |    10 |    38.6908 ns |   0.2964 ns |   0.2627 ns |   5.48 |    0.08 |      - |     - |     - |         - |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |    10 |     8.4304 ns |   0.0501 ns |   0.0444 ns |   1.19 |    0.01 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |    10 |     6.3651 ns |   0.0555 ns |   0.0520 ns |   0.90 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |    10 |    74.6178 ns |   0.5149 ns |   0.4300 ns |  10.55 |    0.12 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |    10 |    22.3996 ns |   0.1414 ns |   0.1254 ns |   3.17 |    0.04 |      - |     - |     - |         - |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |    10 |    48.0315 ns |   0.2339 ns |   0.2188 ns |   6.80 |    0.09 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |    10 |    33.2748 ns |   0.1439 ns |   0.1276 ns |   4.71 |    0.06 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |    10 |    27.9262 ns |   0.0633 ns |   0.0561 ns |   3.95 |    0.04 |      - |     - |     - |         - |
|                      |               |               |       |               |             |             |        |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |  **1000** |   **742.6225 ns** |   **3.1574 ns** |   **2.7989 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |  1000 |   593.6187 ns |   2.4283 ns |   2.2715 ns |   0.80 |    0.00 |      - |     - |     - |         - |
|                 Linq |      .NET 4.8 |      .NET 4.8 |  1000 | 7,017.2567 ns | 131.9007 ns | 129.5441 ns |   9.45 |    0.20 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |  1000 | 2,055.7348 ns |  12.7981 ns |  11.3452 ns |   2.77 |    0.02 |      - |     - |     - |         - |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |  1000 | 3,123.3040 ns |  15.0940 ns |  13.3804 ns |   4.21 |    0.02 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |  1000 | 1,746.5203 ns |   6.7470 ns |   6.3112 ns |   2.35 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |  1000 | 2,193.6542 ns |  10.4222 ns |   9.7489 ns |   2.95 |    0.02 |      - |     - |     - |         - |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |  1000 |   597.5066 ns |   2.9350 ns |   2.4508 ns |   0.80 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |  1000 |   741.5203 ns |   2.4161 ns |   2.2600 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |  1000 | 5,883.5002 ns |  25.4583 ns |  22.5681 ns |   7.92 |    0.05 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |  1000 | 2,526.4961 ns |   9.2700 ns |   8.6711 ns |   3.40 |    0.02 |      - |     - |     - |         - |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |  1000 | 2,861.2727 ns |  13.1169 ns |  11.6278 ns |   3.85 |    0.02 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |  1000 | 1,752.2564 ns |   5.5012 ns |   4.8767 ns |   2.36 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |  1000 | 2,159.2538 ns |  13.1390 ns |  11.6474 ns |   2.91 |    0.02 |      - |     - |     - |         - |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |  1000 |   744.3555 ns |   3.5102 ns |   3.1117 ns |   1.00 |    0.01 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |  1000 |   737.4308 ns |   2.1648 ns |   2.0249 ns |   0.99 |    0.00 |      - |     - |     - |         - |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |  1000 | 5,664.1852 ns |  23.3668 ns |  21.8574 ns |   7.63 |    0.04 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |  1000 | 2,147.1195 ns |  11.4230 ns |  10.6851 ns |   2.89 |    0.02 |      - |     - |     - |         - |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |  1000 | 3,132.6625 ns |   8.3486 ns |   6.9715 ns |   4.22 |    0.02 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |  1000 | 1,471.5806 ns |   7.0371 ns |   6.5825 ns |   1.98 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |  1000 | 1,877.2589 ns |   7.8446 ns |   7.3378 ns |   2.53 |    0.01 |      - |     - |     - |         - |

## ArrayWhereSelect

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET 4.8      : .NET Framework 4.8 (4.8.4180.0), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT


```
|               Method |           Job |       Runtime | Count |          Mean |      Error |     StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |-------------- |-------------- |------ |--------------:|-----------:|-----------:|-------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **0** |     **0.2571 ns** |  **0.0096 ns** |  **0.0080 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |     0 |     0.2893 ns |  0.0068 ns |  0.0057 ns |   1.13 |    0.04 |      - |     - |     - |         - |
|                 Linq |      .NET 4.8 |      .NET 4.8 |     0 |    58.5832 ns |  0.4323 ns |  0.4044 ns | 228.08 |    8.10 | 0.0497 |     - |     - |     104 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |     0 |     9.0008 ns |  0.0866 ns |  0.0768 ns |  35.05 |    1.25 | 0.0115 |     - |     - |      24 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |    40.6581 ns |  0.2739 ns |  0.2562 ns | 158.35 |    4.37 |      - |     - |     - |         - |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |     0 |    41.2645 ns |  0.2065 ns |  0.1724 ns | 160.66 |    5.10 |      - |     - |     - |         - |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |     0 |    61.9674 ns |  0.7572 ns |  0.7083 ns | 240.56 |    7.30 |      - |     - |     - |         - |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |     0.5494 ns |  0.0242 ns |  0.0214 ns |   2.14 |    0.14 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |     0.5519 ns |  0.0110 ns |  0.0092 ns |   2.15 |    0.08 |      - |     - |     - |         - |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |    30.2887 ns |  0.1495 ns |  0.1249 ns | 117.93 |    3.76 |      - |     - |     - |         - |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     0 |     9.4993 ns |  0.1688 ns |  0.1579 ns |  37.06 |    1.41 | 0.0115 |     - |     - |      24 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |    41.0171 ns |  0.1340 ns |  0.1188 ns | 159.71 |    5.11 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |     0 |    41.0602 ns |  0.2007 ns |  0.1877 ns | 159.89 |    5.24 |      - |     - |     - |         - |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |     0 |    42.2522 ns |  0.4490 ns |  0.3981 ns | 164.76 |    5.39 |      - |     - |     - |         - |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |     0.2941 ns |  0.0096 ns |  0.0085 ns |   1.14 |    0.04 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |     0.2452 ns |  0.0125 ns |  0.0117 ns |   0.95 |    0.06 |      - |     - |     - |         - |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |    32.2730 ns |  0.1668 ns |  0.1560 ns | 125.64 |    3.93 |      - |     - |     - |         - |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     0 |     9.7977 ns |  0.0816 ns |  0.0723 ns |  38.12 |    1.14 | 0.0115 |     - |     - |      24 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |    31.0482 ns |  0.1066 ns |  0.0945 ns | 120.83 |    3.68 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |     0 |    32.0530 ns |  0.1468 ns |  0.1373 ns | 124.78 |    4.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |     0 |    28.2030 ns |  0.1781 ns |  0.1579 ns | 109.85 |    3.55 |      - |     - |     - |         - |
|                      |               |               |       |               |            |            |        |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **1** |     **0.4538 ns** |  **0.0071 ns** |  **0.0066 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |     1 |     0.1329 ns |  0.0133 ns |  0.0118 ns |   0.29 |    0.03 |      - |     - |     - |         - |
|                 Linq |      .NET 4.8 |      .NET 4.8 |     1 |    68.9618 ns |  0.4904 ns |  0.4347 ns | 152.07 |    2.56 | 0.0497 |     - |     - |     104 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |     1 |    11.5458 ns |  0.0610 ns |  0.0510 ns |  25.52 |    0.28 | 0.0153 |     - |     - |      32 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |     1 |    46.3629 ns |  0.1264 ns |  0.1182 ns | 102.19 |    1.44 |      - |     - |     - |         - |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |     1 |    45.7997 ns |  0.1459 ns |  0.1365 ns | 100.95 |    1.54 |      - |     - |     - |         - |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |     1 |    68.8428 ns |  0.3135 ns |  0.2779 ns | 151.80 |    2.12 |      - |     - |     - |         - |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |     1 |     0.3683 ns |  0.0125 ns |  0.0117 ns |   0.81 |    0.03 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     1 |     0.3308 ns |  0.0183 ns |  0.0162 ns |   0.73 |    0.04 |      - |     - |     - |         - |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |     1 |    70.2496 ns |  0.5592 ns |  0.4957 ns | 154.91 |    2.36 | 0.0497 |     - |     - |     104 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     1 |    13.1114 ns |  0.0719 ns |  0.0637 ns |  28.91 |    0.46 | 0.0153 |     - |     - |      32 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |     1 |    45.8771 ns |  0.1282 ns |  0.1136 ns | 101.16 |    1.38 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |     1 |    44.9956 ns |  0.2177 ns |  0.2037 ns |  99.17 |    1.49 |      - |     - |     - |         - |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |     1 |    48.4043 ns |  0.5007 ns |  0.4684 ns | 106.70 |    2.31 |      - |     - |     - |         - |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |     1 |     0.3818 ns |  0.0072 ns |  0.0060 ns |   0.84 |    0.02 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     1 |     0.1105 ns |  0.0057 ns |  0.0048 ns |   0.24 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |     1 |    67.7578 ns |  0.4633 ns |  0.4107 ns | 149.42 |    2.56 | 0.0497 |     - |     - |     104 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     1 |    12.3769 ns |  0.1279 ns |  0.1068 ns |  27.35 |    0.38 | 0.0153 |     - |     - |      32 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |     1 |    38.5260 ns |  0.1127 ns |  0.0941 ns |  85.14 |    1.04 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |     1 |    35.4120 ns |  0.1559 ns |  0.1302 ns |  78.26 |    0.92 |      - |     - |     - |         - |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |     1 |    34.7358 ns |  0.2334 ns |  0.2069 ns |  76.60 |    1.10 |      - |     - |     - |         - |
|                      |               |               |       |               |            |            |        |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |    **10** |     **7.0807 ns** |  **0.0464 ns** |  **0.0411 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |    10 |     6.3229 ns |  0.0333 ns |  0.0295 ns |   0.89 |    0.01 |      - |     - |     - |         - |
|                 Linq |      .NET 4.8 |      .NET 4.8 |    10 |   113.2595 ns |  0.6474 ns |  0.5739 ns |  16.00 |    0.13 | 0.0497 |     - |     - |     104 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |    10 |    56.0033 ns |  0.2431 ns |  0.1898 ns |   7.91 |    0.06 | 0.0535 |     - |     - |     112 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |    10 |    78.3150 ns |  0.2601 ns |  0.2172 ns |  11.05 |    0.06 |      - |     - |     - |         - |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |    10 |    58.5915 ns |  0.2989 ns |  0.2796 ns |   8.28 |    0.07 |      - |     - |     - |         - |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |    10 |   121.6413 ns |  0.6028 ns |  0.5344 ns |  17.18 |    0.12 |      - |     - |     - |         - |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |    10 |     6.4644 ns |  0.0699 ns |  0.0620 ns |   0.91 |    0.01 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |    10 |     6.7873 ns |  0.0478 ns |  0.0424 ns |   0.96 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |    10 |   112.6056 ns |  0.4828 ns |  0.4032 ns |  15.90 |    0.11 | 0.0497 |     - |     - |     104 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |    10 |    59.0605 ns |  0.4737 ns |  0.4431 ns |   8.34 |    0.09 | 0.0535 |     - |     - |     112 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |    10 |    74.6786 ns |  0.4484 ns |  0.3744 ns |  10.54 |    0.07 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |    10 |    58.8918 ns |  0.3408 ns |  0.3021 ns |   8.32 |    0.07 |      - |     - |     - |         - |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |    10 |    81.9177 ns |  0.3126 ns |  0.2771 ns |  11.57 |    0.09 |      - |     - |     - |         - |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |    10 |     6.9379 ns |  0.0543 ns |  0.0481 ns |   0.98 |    0.01 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |    10 |     6.6145 ns |  0.0455 ns |  0.0425 ns |   0.93 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |    10 |   112.7351 ns |  0.5695 ns |  0.5048 ns |  15.92 |    0.09 | 0.0497 |     - |     - |     104 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |    10 |    55.3375 ns |  0.1676 ns |  0.1309 ns |   7.81 |    0.05 | 0.0535 |     - |     - |     112 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |    10 |    64.5999 ns |  0.2207 ns |  0.2065 ns |   9.12 |    0.06 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |    10 |    50.1528 ns |  0.4359 ns |  0.3640 ns |   7.08 |    0.06 |      - |     - |     - |         - |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |    10 |    75.3580 ns |  0.3074 ns |  0.2725 ns |  10.64 |    0.07 |      - |     - |     - |         - |
|                      |               |               |       |               |            |            |        |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |  **1000** |   **744.5397 ns** |  **2.9414 ns** |  **2.7514 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |  1000 |   594.3888 ns |  2.9451 ns |  2.7549 ns |   0.80 |    0.01 |      - |     - |     - |         - |
|                 Linq |      .NET 4.8 |      .NET 4.8 |  1000 | 4,957.5066 ns | 25.9145 ns | 24.2404 ns |   6.66 |    0.04 | 0.0458 |     - |     - |     104 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |  1000 | 3,706.9232 ns | 23.1808 ns | 21.6833 ns |   4.98 |    0.03 | 2.8839 |     - |     - |    6067 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |  1000 | 4,120.6157 ns | 37.1675 ns | 32.9480 ns |   5.53 |    0.05 |      - |     - |     - |         - |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |  1000 | 1,682.9392 ns |  5.3319 ns |  4.7266 ns |   2.26 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |  1000 | 6,235.5698 ns | 15.4418 ns | 13.6887 ns |   8.37 |    0.04 |      - |     - |     - |         - |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |  1000 |   597.9215 ns |  4.7002 ns |  4.1666 ns |   0.80 |    0.01 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |  1000 |   739.4012 ns |  2.8102 ns |  2.6286 ns |   0.99 |    0.00 |      - |     - |     - |         - |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |  1000 | 5,187.6205 ns | 20.1236 ns | 17.8391 ns |   6.96 |    0.03 | 0.0458 |     - |     - |     104 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |  1000 | 3,744.0835 ns | 12.5152 ns | 11.0944 ns |   5.03 |    0.02 | 2.8877 |     - |     - |    6048 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |  1000 | 4,597.5826 ns | 20.9527 ns | 17.4964 ns |   6.17 |    0.03 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |  1000 | 1,525.8015 ns |  9.3703 ns |  8.3065 ns |   2.05 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |  1000 | 4,974.3403 ns | 17.3503 ns | 15.3806 ns |   6.68 |    0.03 |      - |     - |     - |         - |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |  1000 |   744.7966 ns |  2.8463 ns |  2.5232 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |  1000 |   738.6302 ns |  2.3986 ns |  2.2436 ns |   0.99 |    0.00 |      - |     - |     - |         - |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |  1000 | 5,038.3844 ns | 16.0875 ns | 15.0482 ns |   6.77 |    0.03 | 0.0458 |     - |     - |     104 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |  1000 | 3,427.7033 ns | 19.0000 ns | 16.8430 ns |   4.60 |    0.02 | 2.8877 |     - |     - |    6048 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |  1000 | 4,491.7990 ns | 20.1026 ns | 16.7866 ns |   6.03 |    0.03 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |  1000 | 1,489.9440 ns |  7.6645 ns |  6.7944 ns |   2.00 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |  1000 | 4,610.5995 ns | 22.7648 ns | 20.1804 ns |   6.19 |    0.04 |      - |     - |     - |         - |

## ArrayWhereSelectToArray

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET 4.8      : .NET Framework 4.8 (4.8.4180.0), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT


```
|               Method |           Job |       Runtime | Count |         Mean |      Error |     StdDev |       Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |-------------- |-------------- |------ |-------------:|-----------:|-----------:|-------------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **0** |    **17.016 ns** |  **0.0985 ns** |  **0.0873 ns** |    **17.025 ns** |  **1.00** |    **0.00** | **0.0306** |     **-** |     **-** |      **64 B** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |     0 |    17.019 ns |  0.0915 ns |  0.0811 ns |    16.998 ns |  1.00 |    0.01 | 0.0306 |     - |     - |      64 B |
|                 Linq |      .NET 4.8 |      .NET 4.8 |     0 |    74.115 ns |  0.3720 ns |  0.3297 ns |    74.078 ns |  4.36 |    0.03 | 0.0612 |     - |     - |     128 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |     0 |     6.904 ns |  0.0402 ns |  0.0376 ns |     6.895 ns |  0.41 |    0.00 | 0.0115 |     - |     - |      24 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |    70.764 ns |  0.3660 ns |  0.3245 ns |    70.792 ns |  4.16 |    0.03 | 0.0535 |     - |     - |     112 B |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |     0 |    71.997 ns |  0.5007 ns |  0.4683 ns |    71.948 ns |  4.23 |    0.03 | 0.0535 |     - |     - |     112 B |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |     0 |    90.493 ns |  0.4823 ns |  0.4275 ns |    90.428 ns |  5.32 |    0.04 | 0.0114 |     - |     - |      24 B |
|       Hyperlinq_Pool |      .NET 4.8 |      .NET 4.8 |     0 |           NA |         NA |         NA |           NA |     ? |       ? |      - |     - |     - |         - |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |     6.645 ns |  0.0626 ns |  0.0585 ns |     6.631 ns |  0.39 |    0.00 | 0.0153 |     - |     - |      32 B |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |     7.015 ns |  0.1165 ns |  0.0909 ns |     6.999 ns |  0.41 |    0.00 | 0.0153 |     - |     - |      32 B |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |    29.300 ns |  0.1782 ns |  0.1580 ns |    29.298 ns |  1.72 |    0.01 |      - |     - |     - |         - |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     0 |     7.424 ns |  0.0639 ns |  0.0533 ns |     7.417 ns |  0.44 |    0.00 | 0.0115 |     - |     - |      24 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |    57.956 ns |  0.3479 ns |  0.3084 ns |    57.968 ns |  3.41 |    0.03 | 0.0381 |     - |     - |      80 B |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |     0 |    60.837 ns |  0.6792 ns |  0.5303 ns |    60.741 ns |  3.58 |    0.04 | 0.0381 |     - |     - |      80 B |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |     0 |    73.151 ns |  0.5732 ns |  0.5082 ns |    73.283 ns |  4.30 |    0.04 | 0.0113 |     - |     - |      24 B |
|       Hyperlinq_Pool | .NET Core 3.1 | .NET Core 3.1 |     0 |           NA |         NA |         NA |           NA |     ? |       ? |      - |     - |     - |         - |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |     7.005 ns |  0.0672 ns |  0.0629 ns |     7.007 ns |  0.41 |    0.00 | 0.0153 |     - |     - |      32 B |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |     7.786 ns |  0.0846 ns |  0.0792 ns |     7.798 ns |  0.46 |    0.01 | 0.0153 |     - |     - |      32 B |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |    29.751 ns |  0.1186 ns |  0.1109 ns |    29.770 ns |  1.75 |    0.01 |      - |     - |     - |         - |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     0 |     7.470 ns |  0.0863 ns |  0.0765 ns |     7.458 ns |  0.44 |    0.01 | 0.0114 |     - |     - |      24 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |    42.641 ns |  0.3695 ns |  0.3085 ns |    42.554 ns |  2.51 |    0.02 | 0.0382 |     - |     - |      80 B |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |     0 |    43.907 ns |  0.2788 ns |  0.2328 ns |    43.898 ns |  2.58 |    0.02 | 0.0382 |     - |     - |      80 B |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |     0 |    48.931 ns |  0.3224 ns |  0.2692 ns |    48.920 ns |  2.88 |    0.02 | 0.0114 |     - |     - |      24 B |
|       Hyperlinq_Pool | .NET Core 5.0 | .NET Core 5.0 |     0 |           NA |         NA |         NA |           NA |     ? |       ? |      - |     - |     - |         - |
|                      |               |               |       |              |            |            |              |       |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **1** |    **34.783 ns** |  **0.2481 ns** |  **0.2200 ns** |    **34.777 ns** |  **1.00** |    **0.00** | **0.0535** |     **-** |     **-** |     **112 B** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |     1 |    35.152 ns |  0.2484 ns |  0.2323 ns |    35.149 ns |  1.01 |    0.01 | 0.0535 |     - |     - |     112 B |
|                 Linq |      .NET 4.8 |      .NET 4.8 |     1 |   102.211 ns |  0.3645 ns |  0.3043 ns |   102.212 ns |  2.94 |    0.02 | 0.0842 |     - |     - |     177 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |     1 |    10.569 ns |  0.0661 ns |  0.0619 ns |    10.578 ns |  0.30 |    0.00 | 0.0153 |     - |     - |      32 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |     1 |    90.405 ns |  0.3680 ns |  0.3262 ns |    90.387 ns |  2.60 |    0.02 | 0.0764 |     - |     - |     160 B |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |     1 |    89.121 ns |  0.4224 ns |  0.3527 ns |    89.005 ns |  2.56 |    0.02 | 0.0764 |     - |     - |     160 B |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |     1 |   155.995 ns |  0.8928 ns |  0.7914 ns |   156.148 ns |  4.49 |    0.04 | 0.0153 |     - |     - |      32 B |
|       Hyperlinq_Pool |      .NET 4.8 |      .NET 4.8 |     1 |   274.381 ns |  1.3656 ns |  1.2106 ns |   274.391 ns |  7.89 |    0.06 | 0.0267 |     - |     - |      56 B |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |     1 |    33.010 ns |  0.2863 ns |  0.2678 ns |    32.991 ns |  0.95 |    0.01 | 0.0497 |     - |     - |     104 B |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     1 |    32.762 ns |  0.3049 ns |  0.2703 ns |    32.795 ns |  0.94 |    0.01 | 0.0497 |     - |     - |     104 B |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |     1 |    96.348 ns |  1.9878 ns |  3.6347 ns |    97.969 ns |  2.65 |    0.09 | 0.0648 |     - |     - |     136 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     1 |    10.955 ns |  0.0589 ns |  0.0523 ns |    10.947 ns |  0.31 |    0.00 | 0.0153 |     - |     - |      32 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |     1 |    87.250 ns |  0.5827 ns |  0.5165 ns |    87.393 ns |  2.51 |    0.02 | 0.0725 |     - |     - |     152 B |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |     1 |    86.514 ns |  1.0158 ns |  0.9005 ns |    86.616 ns |  2.49 |    0.03 | 0.0726 |     - |     - |     152 B |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |     1 |   120.910 ns |  0.7284 ns |  0.6457 ns |   120.886 ns |  3.48 |    0.03 | 0.0153 |     - |     - |      32 B |
|       Hyperlinq_Pool | .NET Core 3.1 | .NET Core 3.1 |     1 |   241.082 ns |  1.9333 ns |  1.7138 ns |   241.244 ns |  6.93 |    0.06 | 0.0267 |     - |     - |      56 B |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |     1 |    26.560 ns |  0.2672 ns |  0.2232 ns |    26.522 ns |  0.76 |    0.01 | 0.0497 |     - |     - |     104 B |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     1 |    28.711 ns |  0.1875 ns |  0.1662 ns |    28.714 ns |  0.83 |    0.01 | 0.0497 |     - |     - |     104 B |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |     1 |    88.988 ns |  0.4327 ns |  0.3835 ns |    88.946 ns |  2.56 |    0.02 | 0.0648 |     - |     - |     136 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     1 |    10.560 ns |  0.0972 ns |  0.0862 ns |    10.545 ns |  0.30 |    0.00 | 0.0153 |     - |     - |      32 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |     1 |    67.749 ns |  0.7424 ns |  0.6581 ns |    67.724 ns |  1.95 |    0.02 | 0.0726 |     - |     - |     152 B |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |     1 |    66.290 ns |  0.4549 ns |  0.4033 ns |    66.258 ns |  1.91 |    0.02 | 0.0725 |     - |     - |     152 B |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |     1 |    86.374 ns |  0.3478 ns |  0.3083 ns |    86.418 ns |  2.48 |    0.02 | 0.0150 |     - |     - |      32 B |
|       Hyperlinq_Pool | .NET Core 5.0 | .NET Core 5.0 |     1 |   221.607 ns |  1.3262 ns |  1.1757 ns |   221.632 ns |  6.37 |    0.06 | 0.0267 |     - |     - |      56 B |
|                      |               |               |       |              |            |            |              |       |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |    **10** |    **73.167 ns** |  **0.3292 ns** |  **0.3080 ns** |    **73.167 ns** |  **1.00** |    **0.00** | **0.0880** |     **-** |     **-** |     **185 B** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |    10 |    72.710 ns |  0.7728 ns |  0.7229 ns |    72.536 ns |  0.99 |    0.01 | 0.0880 |     - |     - |     185 B |
|                 Linq |      .NET 4.8 |      .NET 4.8 |    10 |   173.031 ns |  1.1923 ns |  1.1153 ns |   172.704 ns |  2.36 |    0.02 | 0.1185 |     - |     - |     249 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |    10 |    59.751 ns |  0.3146 ns |  0.2943 ns |    59.714 ns |  0.82 |    0.01 | 0.0535 |     - |     - |     112 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |    10 |   175.101 ns |  0.8761 ns |  0.8195 ns |   175.195 ns |  2.39 |    0.02 | 0.1109 |     - |     - |     233 B |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |    10 |   130.154 ns |  0.6010 ns |  0.5622 ns |   129.986 ns |  1.78 |    0.01 | 0.1109 |     - |     - |     233 B |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |    10 |   196.249 ns |  1.1065 ns |  0.9809 ns |   196.196 ns |  2.68 |    0.02 | 0.0229 |     - |     - |      48 B |
|       Hyperlinq_Pool |      .NET 4.8 |      .NET 4.8 |    10 |   311.577 ns |  1.6183 ns |  1.4346 ns |   311.414 ns |  4.26 |    0.02 | 0.0267 |     - |     - |      56 B |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |    10 |    69.379 ns |  0.4640 ns |  0.4113 ns |    69.310 ns |  0.95 |    0.01 | 0.0842 |     - |     - |     176 B |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |    10 |    65.081 ns |  0.7329 ns |  0.6120 ns |    65.019 ns |  0.89 |    0.01 | 0.0842 |     - |     - |     176 B |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |    10 |   159.965 ns |  1.1825 ns |  0.9874 ns |   159.726 ns |  2.19 |    0.02 | 0.1185 |     - |     - |     248 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |    10 |    55.743 ns |  0.4224 ns |  0.3745 ns |    55.793 ns |  0.76 |    0.01 | 0.0534 |     - |     - |     112 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |    10 |   148.189 ns |  1.0823 ns |  1.0124 ns |   148.172 ns |  2.03 |    0.02 | 0.1070 |     - |     - |     224 B |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |    10 |   128.378 ns |  0.8484 ns |  0.7936 ns |   128.448 ns |  1.75 |    0.01 | 0.1070 |     - |     - |     224 B |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |    10 |   153.029 ns |  1.1221 ns |  0.9947 ns |   153.349 ns |  2.09 |    0.02 | 0.0229 |     - |     - |      48 B |
|       Hyperlinq_Pool | .NET Core 3.1 | .NET Core 3.1 |    10 |   269.404 ns |  2.0226 ns |  1.7930 ns |   269.184 ns |  3.68 |    0.03 | 0.0267 |     - |     - |      56 B |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |    10 |    53.143 ns |  0.3705 ns |  0.3284 ns |    53.121 ns |  0.73 |    0.01 | 0.0840 |     - |     - |     176 B |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |    10 |    54.348 ns |  0.4505 ns |  0.3994 ns |    54.341 ns |  0.74 |    0.01 | 0.0842 |     - |     - |     176 B |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |    10 |   158.866 ns |  0.7794 ns |  0.6508 ns |   159.111 ns |  2.17 |    0.01 | 0.1183 |     - |     - |     248 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |    10 |    48.881 ns |  0.1711 ns |  0.1336 ns |    48.868 ns |  0.67 |    0.00 | 0.0535 |     - |     - |     112 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |    10 |   125.543 ns |  0.8181 ns |  0.7653 ns |   125.770 ns |  1.72 |    0.01 | 0.1070 |     - |     - |     224 B |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |    10 |    99.303 ns |  0.6694 ns |  0.5934 ns |    99.125 ns |  1.36 |    0.01 | 0.1069 |     - |     - |     224 B |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |    10 |   122.614 ns |  0.6225 ns |  0.5823 ns |   122.624 ns |  1.68 |    0.01 | 0.0229 |     - |     - |      48 B |
|       Hyperlinq_Pool | .NET Core 5.0 | .NET Core 5.0 |    10 |   224.913 ns |  0.8154 ns |  0.7627 ns |   225.192 ns |  3.07 |    0.02 | 0.0267 |     - |     - |      56 B |
|                      |               |               |       |              |            |            |              |       |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |  **1000** | **2,313.728 ns** |  **7.3160 ns** |  **6.4855 ns** | **2,311.723 ns** |  **1.00** |    **0.00** | **3.0289** |     **-** |     **-** |    **6355 B** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |  1000 | 1,961.669 ns |  7.3323 ns |  6.1228 ns | 1,961.856 ns |  0.85 |    0.00 | 3.0289 |     - |     - |    6355 B |
|                 Linq |      .NET 4.8 |      .NET 4.8 |  1000 | 6,315.855 ns | 39.9562 ns | 35.4201 ns | 6,311.490 ns |  2.73 |    0.02 | 3.0518 |     - |     - |    6420 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |  1000 | 4,248.248 ns | 17.0570 ns | 14.2433 ns | 4,251.560 ns |  1.84 |    0.01 | 2.8839 |     - |     - |    6067 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |  1000 | 6,218.805 ns | 31.4378 ns | 26.2520 ns | 6,222.771 ns |  2.69 |    0.02 | 3.0441 |     - |     - |    6404 B |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |  1000 | 3,202.629 ns | 12.9104 ns | 11.4447 ns | 3,203.887 ns |  1.38 |    0.01 | 3.0479 |     - |     - |    6404 B |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |  1000 | 5,241.796 ns | 21.2856 ns | 19.9105 ns | 5,244.090 ns |  2.27 |    0.01 | 0.9613 |     - |     - |    2030 B |
|       Hyperlinq_Pool |      .NET 4.8 |      .NET 4.8 |  1000 | 4,823.316 ns | 15.5711 ns | 13.8034 ns | 4,825.726 ns |  2.08 |    0.01 | 0.0229 |     - |     - |      56 B |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |  1000 | 1,705.102 ns | 13.1126 ns | 11.6240 ns | 1,701.927 ns |  0.74 |    0.01 | 3.0251 |     - |     - |    6328 B |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |  1000 | 1,642.883 ns | 11.3613 ns | 10.0715 ns | 1,642.577 ns |  0.71 |    0.00 | 3.0251 |     - |     - |    6328 B |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |  1000 | 4,026.024 ns | 17.7077 ns | 13.8250 ns | 4,031.700 ns |  1.74 |    0.01 | 2.1591 |     - |     - |    4528 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |  1000 | 3,365.862 ns | 21.7291 ns | 20.3254 ns | 3,359.320 ns |  1.45 |    0.01 | 2.8877 |     - |     - |    6048 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |  1000 | 5,107.494 ns | 19.3984 ns | 17.1962 ns | 5,105.605 ns |  2.21 |    0.01 | 3.0441 |     - |     - |    6376 B |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |  1000 | 2,515.536 ns | 15.3472 ns | 14.3557 ns | 2,514.261 ns |  1.09 |    0.01 | 3.0479 |     - |     - |    6376 B |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |  1000 | 4,228.128 ns | 20.5501 ns | 17.1603 ns | 4,232.783 ns |  1.83 |    0.01 | 0.9613 |     - |     - |    2024 B |
|       Hyperlinq_Pool | .NET Core 3.1 | .NET Core 3.1 |  1000 | 4,122.585 ns | 14.2734 ns | 11.9189 ns | 4,118.430 ns |  1.78 |    0.01 | 0.0229 |     - |     - |      56 B |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |  1000 | 1,646.472 ns | 13.1446 ns | 11.6523 ns | 1,645.667 ns |  0.71 |    0.01 | 3.0251 |     - |     - |    6328 B |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |  1000 | 1,646.332 ns | 11.4121 ns | 10.1165 ns | 1,647.744 ns |  0.71 |    0.00 | 3.0251 |     - |     - |    6328 B |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |  1000 | 4,457.647 ns | 28.8983 ns | 27.0315 ns | 4,455.123 ns |  1.93 |    0.01 | 2.1591 |     - |     - |    4528 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |  1000 | 3,213.888 ns | 19.9470 ns | 17.6825 ns | 3,210.205 ns |  1.39 |    0.01 | 2.8877 |     - |     - |    6048 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |  1000 | 5,162.229 ns | 37.8076 ns | 33.5155 ns | 5,162.788 ns |  2.23 |    0.02 | 3.0441 |     - |     - |    6376 B |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |  1000 | 2,471.366 ns | 20.4236 ns | 19.1043 ns | 2,468.542 ns |  1.07 |    0.01 | 3.0479 |     - |     - |    6376 B |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |  1000 | 3,758.388 ns | 19.7899 ns | 17.5432 ns | 3,759.551 ns |  1.62 |    0.01 | 0.9651 |     - |     - |    2024 B |
|       Hyperlinq_Pool | .NET Core 5.0 | .NET Core 5.0 |  1000 | 4,037.450 ns | 15.7109 ns | 14.6960 ns | 4,039.977 ns |  1.75 |    0.01 | 0.0229 |     - |     - |      56 B |

Benchmarks with issues:
  ArrayWhereSelectToArray.Hyperlinq_Pool: .NET 4.8(Runtime=.NET 4.8) [Count=0]
  ArrayWhereSelectToArray.Hyperlinq_Pool: .NET Core 3.1(Runtime=.NET Core 3.1) [Count=0]
  ArrayWhereSelectToArray.Hyperlinq_Pool: .NET Core 5.0(Runtime=.NET Core 5.0) [Count=0]

## ArrayWhereSelectToList

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET 4.8      : .NET Framework 4.8 (4.8.4180.0), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT


```
|               Method |           Job |       Runtime | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |-------------- |-------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **0** |     **8.634 ns** |  **0.0850 ns** |  **0.0754 ns** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |     0 |     8.576 ns |  0.0469 ns |  0.0392 ns |  0.99 |    0.01 | 0.0191 |     - |     - |      40 B |
|                 Linq |      .NET 4.8 |      .NET 4.8 |     0 |    88.717 ns |  0.3990 ns |  0.3537 ns | 10.28 |    0.10 | 0.0688 |     - |     - |     144 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |     0 |    44.525 ns |  0.3004 ns |  0.2810 ns |  5.16 |    0.06 | 0.0306 |     - |     - |      64 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |    60.683 ns |  0.2398 ns |  0.2243 ns |  7.03 |    0.06 | 0.0421 |     - |     - |      88 B |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |     0 |    62.039 ns |  0.6361 ns |  0.4966 ns |  7.20 |    0.07 | 0.0421 |     - |     - |      88 B |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |     0 |   114.668 ns |  0.4099 ns |  0.3835 ns | 13.28 |    0.12 | 0.0534 |     - |     - |     112 B |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |     5.838 ns |  0.0490 ns |  0.0434 ns |  0.68 |    0.01 | 0.0153 |     - |     - |      32 B |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |     6.310 ns |  0.0499 ns |  0.0390 ns |  0.73 |    0.01 | 0.0153 |     - |     - |      32 B |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |    33.399 ns |  0.2384 ns |  0.1991 ns |  3.87 |    0.04 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     0 |    28.406 ns |  0.2893 ns |  0.2565 ns |  3.29 |    0.04 | 0.0267 |     - |     - |      56 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |    57.284 ns |  0.4025 ns |  0.3361 ns |  6.64 |    0.07 | 0.0381 |     - |     - |      80 B |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |     0 |    59.597 ns |  0.4502 ns |  0.3991 ns |  6.90 |    0.09 | 0.0381 |     - |     - |      80 B |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |     0 |    94.853 ns |  0.5003 ns |  0.4178 ns | 10.99 |    0.10 | 0.0496 |     - |     - |     104 B |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |     5.687 ns |  0.0532 ns |  0.0497 ns |  0.66 |    0.01 | 0.0153 |     - |     - |      32 B |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |     6.241 ns |  0.0588 ns |  0.0522 ns |  0.72 |    0.01 | 0.0153 |     - |     - |      32 B |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |    33.008 ns |  0.1371 ns |  0.1282 ns |  3.82 |    0.04 | 0.0152 |     - |     - |      32 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     0 |    23.457 ns |  0.1943 ns |  0.1622 ns |  2.72 |    0.03 | 0.0267 |     - |     - |      56 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |    41.788 ns |  0.2166 ns |  0.1921 ns |  4.84 |    0.04 | 0.0381 |     - |     - |      80 B |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |     0 |    43.399 ns |  0.1702 ns |  0.1421 ns |  5.03 |    0.04 | 0.0381 |     - |     - |      80 B |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |     0 |    72.947 ns |  0.3410 ns |  0.2662 ns |  8.46 |    0.08 | 0.0495 |     - |     - |     104 B |
|                      |               |               |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **1** |    **20.599 ns** |  **0.1228 ns** |  **0.1089 ns** |  **1.00** |    **0.00** | **0.0382** |     **-** |     **-** |      **80 B** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |     1 |    20.733 ns |  0.1893 ns |  0.1678 ns |  1.01 |    0.01 | 0.0382 |     - |     - |      80 B |
|                 Linq |      .NET 4.8 |      .NET 4.8 |     1 |   111.244 ns |  0.6176 ns |  0.5475 ns |  5.40 |    0.03 | 0.0880 |     - |     - |     185 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |     1 |    62.707 ns |  0.4403 ns |  0.3438 ns |  3.04 |    0.03 | 0.0497 |     - |     - |     104 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |     1 |    77.821 ns |  0.6340 ns |  0.5620 ns |  3.78 |    0.04 | 0.0612 |     - |     - |     128 B |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |     1 |    86.215 ns |  0.2917 ns |  0.2436 ns |  4.19 |    0.03 | 0.0612 |     - |     - |     128 B |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |     1 |   188.232 ns |  0.9843 ns |  0.9207 ns |  9.14 |    0.07 | 0.0687 |     - |     - |     144 B |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |     1 |    17.253 ns |  0.2162 ns |  0.2022 ns |  0.84 |    0.01 | 0.0344 |     - |     - |      72 B |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     1 |    17.028 ns |  0.1688 ns |  0.1496 ns |  0.83 |    0.01 | 0.0344 |     - |     - |      72 B |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |     1 |    71.902 ns |  0.5782 ns |  0.5126 ns |  3.49 |    0.03 | 0.0840 |     - |     - |     176 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     1 |    47.483 ns |  0.3095 ns |  0.2895 ns |  2.30 |    0.02 | 0.0458 |     - |     - |      96 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |     1 |    73.249 ns |  0.3633 ns |  0.3221 ns |  3.56 |    0.02 | 0.0572 |     - |     - |     120 B |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |     1 |    74.182 ns |  1.0718 ns |  1.0026 ns |  3.60 |    0.05 | 0.0573 |     - |     - |     120 B |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |     1 |   151.324 ns |  0.9136 ns |  0.8099 ns |  7.35 |    0.06 | 0.0648 |     - |     - |     136 B |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |     1 |    18.386 ns |  0.1871 ns |  0.1750 ns |  0.89 |    0.01 | 0.0344 |     - |     - |      72 B |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     1 |    17.942 ns |  0.1775 ns |  0.1573 ns |  0.87 |    0.01 | 0.0344 |     - |     - |      72 B |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |     1 |    76.111 ns |  1.5252 ns |  1.4267 ns |  3.69 |    0.07 | 0.0839 |     - |     - |     176 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     1 |    40.510 ns |  0.2351 ns |  0.1963 ns |  1.97 |    0.02 | 0.0458 |     - |     - |      96 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |     1 |    58.194 ns |  0.3021 ns |  0.2826 ns |  2.82 |    0.02 | 0.0571 |     - |     - |     120 B |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |     1 |    56.912 ns |  0.3062 ns |  0.2864 ns |  2.76 |    0.02 | 0.0571 |     - |     - |     120 B |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |     1 |   130.785 ns |  1.0683 ns |  0.9993 ns |  6.35 |    0.05 | 0.0648 |     - |     - |     136 B |
|                      |               |               |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |    **10** |    **60.166 ns** |  **0.3183 ns** |  **0.2658 ns** |  **1.00** |    **0.00** | **0.0650** |     **-** |     **-** |     **136 B** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |    10 |    57.275 ns |  0.4262 ns |  0.3987 ns |  0.95 |    0.01 | 0.0650 |     - |     - |     136 B |
|                 Linq |      .NET 4.8 |      .NET 4.8 |    10 |   189.298 ns |  0.5466 ns |  0.4564 ns |  3.15 |    0.01 | 0.1147 |     - |     - |     241 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |    10 |   107.949 ns |  0.5247 ns |  0.4382 ns |  1.79 |    0.01 | 0.0956 |     - |     - |     201 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |    10 |   146.808 ns |  1.1001 ns |  0.9752 ns |  2.44 |    0.02 | 0.0880 |     - |     - |     185 B |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |    10 |   115.248 ns |  0.7460 ns |  0.6230 ns |  1.92 |    0.01 | 0.0880 |     - |     - |     185 B |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |    10 |   228.025 ns |  1.2574 ns |  1.1146 ns |  3.79 |    0.03 | 0.0763 |     - |     - |     160 B |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |    10 |    51.534 ns |  0.1909 ns |  0.1785 ns |  0.86 |    0.00 | 0.0612 |     - |     - |     128 B |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |    10 |    50.673 ns |  0.2003 ns |  0.1564 ns |  0.84 |    0.00 | 0.0612 |     - |     - |     128 B |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |    10 |   131.367 ns |  1.0827 ns |  0.9041 ns |  2.18 |    0.02 | 0.1109 |     - |     - |     232 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |    10 |    95.398 ns |  0.4806 ns |  0.4496 ns |  1.58 |    0.01 | 0.0918 |     - |     - |     192 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |    10 |   134.892 ns |  1.1406 ns |  1.0669 ns |  2.24 |    0.02 | 0.0842 |     - |     - |     176 B |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |    10 |   110.061 ns |  1.7322 ns |  1.5355 ns |  1.83 |    0.03 | 0.0842 |     - |     - |     176 B |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |    10 |   184.889 ns |  0.6774 ns |  0.6005 ns |  3.07 |    0.02 | 0.0725 |     - |     - |     152 B |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |    10 |    44.239 ns |  0.3059 ns |  0.2554 ns |  0.74 |    0.00 | 0.0612 |     - |     - |     128 B |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |    10 |    45.339 ns |  0.2215 ns |  0.1850 ns |  0.75 |    0.00 | 0.0611 |     - |     - |     128 B |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |    10 |   129.639 ns |  0.7960 ns |  0.7446 ns |  2.16 |    0.01 | 0.1104 |     - |     - |     232 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |    10 |    82.614 ns |  0.6892 ns |  0.6447 ns |  1.37 |    0.01 | 0.0916 |     - |     - |     192 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |    10 |   110.176 ns |  0.7751 ns |  0.6871 ns |  1.83 |    0.01 | 0.0842 |     - |     - |     176 B |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |    10 |    86.555 ns |  0.7035 ns |  0.6236 ns |  1.44 |    0.01 | 0.0842 |     - |     - |     176 B |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |    10 |   151.399 ns |  1.1123 ns |  0.9288 ns |  2.52 |    0.02 | 0.0722 |     - |     - |     152 B |
|                      |               |               |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |  **1000** | **2,229.155 ns** | **11.8450 ns** |  **9.8911 ns** |  **1.00** |    **0.00** | **2.0599** |     **-** |     **-** |    **4325 B** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |  1000 | 1,978.649 ns | 14.2705 ns | 13.3487 ns |  0.89 |    0.01 | 2.0599 |     - |     - |    4325 B |
|                 Linq |      .NET 4.8 |      .NET 4.8 |  1000 | 7,060.754 ns | 33.1781 ns | 31.0348 ns |  3.17 |    0.02 | 2.1057 |     - |     - |    4430 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |  1000 | 3,891.554 ns | 14.2836 ns | 13.3609 ns |  1.75 |    0.01 | 3.8757 |     - |     - |    8136 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |  1000 | 6,148.237 ns | 42.4099 ns | 35.4142 ns |  2.76 |    0.02 | 2.0828 |     - |     - |    4373 B |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |  1000 | 3,081.779 ns | 52.2329 ns | 43.6168 ns |  1.38 |    0.02 | 2.0828 |     - |     - |    4373 B |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |  1000 | 4,938.324 ns | 19.5543 ns | 17.3344 ns |  2.22 |    0.02 | 1.0147 |     - |     - |    2144 B |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |  1000 | 1,621.511 ns | 12.3095 ns | 11.5143 ns |  0.73 |    0.01 | 2.0561 |     - |     - |    4304 B |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |  1000 | 1,514.493 ns | 12.0869 ns | 11.3061 ns |  0.68 |    0.01 | 2.0561 |     - |     - |    4304 B |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |  1000 | 3,954.293 ns | 11.9217 ns | 10.5683 ns |  1.77 |    0.01 | 2.1057 |     - |     - |    4408 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |  1000 | 3,998.358 ns | 26.7613 ns | 25.0326 ns |  1.79 |    0.01 | 3.8681 |     - |     - |    8104 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |  1000 | 5,416.257 ns | 29.7259 ns | 27.8057 ns |  2.43 |    0.01 | 2.0752 |     - |     - |    4352 B |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |  1000 | 2,377.314 ns | 14.8651 ns | 13.1776 ns |  1.07 |    0.01 | 2.0790 |     - |     - |    4352 B |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |  1000 | 4,584.977 ns | 20.4172 ns | 18.0993 ns |  2.06 |    0.02 | 1.0147 |     - |     - |    2128 B |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |  1000 | 1,550.000 ns | 10.7362 ns |  9.5174 ns |  0.70 |    0.01 | 2.0561 |     - |     - |    4304 B |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |  1000 | 1,494.788 ns | 11.8257 ns | 10.4831 ns |  0.67 |    0.00 | 2.0561 |     - |     - |    4304 B |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |  1000 | 3,701.780 ns | 18.3067 ns | 16.2284 ns |  1.66 |    0.01 | 2.1057 |     - |     - |    4408 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |  1000 | 3,687.939 ns |  8.5109 ns |  7.1070 ns |  1.65 |    0.01 | 3.8681 |     - |     - |    8104 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |  1000 | 4,878.911 ns | 33.6355 ns | 29.8170 ns |  2.19 |    0.02 | 2.0752 |     - |     - |    4352 B |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |  1000 | 2,302.266 ns | 12.5139 ns | 11.0933 ns |  1.03 |    0.01 | 2.0790 |     - |     - |    4352 B |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |  1000 | 3,938.910 ns | 25.8540 ns | 24.1838 ns |  1.77 |    0.01 | 1.0147 |     - |     - |    2128 B |

## ListDistinct

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET 4.8      : .NET Framework 4.8 (4.8.4180.0), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT


```
|      Method |           Job |       Runtime | Count |          Mean |       Error |      StdDev |        Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |-------------- |-------------- |------ |--------------:|------------:|------------:|--------------:|------:|--------:|--------:|------:|------:|----------:|
|     **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **0** |     **11.186 ns** |   **0.0691 ns** |   **0.0613 ns** |     **11.169 ns** |  **1.00** |    **0.00** |  **0.0306** |     **-** |     **-** |      **64 B** |
| ForeachLoop |      .NET 4.8 |      .NET 4.8 |     0 |     21.251 ns |   0.2101 ns |   0.1863 ns |     21.232 ns |  1.90 |    0.02 |  0.0306 |     - |     - |      64 B |
|        Linq |      .NET 4.8 |      .NET 4.8 |     0 |     71.585 ns |   0.5714 ns |   0.5066 ns |     71.607 ns |  6.40 |    0.06 |  0.1606 |     - |     - |     337 B |
|  LinqFaster |      .NET 4.8 |      .NET 4.8 |     0 |            NA |          NA |          NA |            NA |     ? |       ? |       - |     - |     - |         - |
|  StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |    201.832 ns |   0.9377 ns |   0.8313 ns |    201.558 ns | 18.04 |    0.14 |       - |     - |     - |         - |
|   Hyperlinq |      .NET 4.8 |      .NET 4.8 |     0 |     76.210 ns |   0.4501 ns |   0.4210 ns |     76.191 ns |  6.82 |    0.05 |       - |     - |     - |         - |
|     ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |      9.368 ns |   0.2168 ns |   0.4329 ns |      9.537 ns |  0.80 |    0.05 |  0.0306 |     - |     - |      64 B |
| ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |     10.806 ns |   0.0723 ns |   0.0604 ns |     10.811 ns |  0.97 |    0.01 |  0.0306 |     - |     - |      64 B |
|        Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |     45.881 ns |   0.4364 ns |   0.3869 ns |     45.831 ns |  4.10 |    0.04 |  0.0497 |     - |     - |     104 B |
|  LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     0 |            NA |          NA |          NA |            NA |     ? |       ? |       - |     - |     - |         - |
|  StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |    150.358 ns |   0.6703 ns |   0.5942 ns |    150.314 ns | 13.44 |    0.10 |       - |     - |     - |         - |
|   Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |     0 |     58.748 ns |   0.3964 ns |   0.3514 ns |     58.647 ns |  5.25 |    0.04 |       - |     - |     - |         - |
|     ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |      6.579 ns |   0.0770 ns |   0.0683 ns |      6.579 ns |  0.59 |    0.01 |  0.0344 |     - |     - |      72 B |
| ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |      9.620 ns |   0.1002 ns |   0.0937 ns |      9.600 ns |  0.86 |    0.01 |  0.0344 |     - |     - |      72 B |
|        Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |     47.568 ns |   0.3546 ns |   0.3317 ns |     47.564 ns |  4.25 |    0.03 |  0.0497 |     - |     - |     104 B |
|  LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     0 |            NA |          NA |          NA |            NA |     ? |       ? |       - |     - |     - |         - |
|  StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |    115.672 ns |   0.4744 ns |   0.4206 ns |    115.505 ns | 10.34 |    0.06 |       - |     - |     - |         - |
|   Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |     0 |     37.609 ns |   0.2757 ns |   0.2579 ns |     37.607 ns |  3.36 |    0.03 |       - |     - |     - |         - |
|             |               |               |       |               |             |             |               |       |         |         |       |       |           |
|     **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **1** |     **45.557 ns** |   **0.2949 ns** |   **0.2614 ns** |     **45.562 ns** |  **1.00** |    **0.00** |  **0.0803** |     **-** |     **-** |     **168 B** |
| ForeachLoop |      .NET 4.8 |      .NET 4.8 |     1 |     54.952 ns |   0.3816 ns |   0.3186 ns |     54.949 ns |  1.21 |    0.01 |  0.0803 |     - |     - |     168 B |
|        Linq |      .NET 4.8 |      .NET 4.8 |     1 |     93.823 ns |   0.4326 ns |   0.4046 ns |     93.930 ns |  2.06 |    0.01 |  0.1606 |     - |     - |     337 B |
|  LinqFaster |      .NET 4.8 |      .NET 4.8 |     1 |     13.979 ns |   0.0545 ns |   0.0455 ns |     13.973 ns |  0.31 |    0.00 |       - |     - |     - |         - |
|  StructLinq |      .NET 4.8 |      .NET 4.8 |     1 |    216.928 ns |   1.0309 ns |   0.9139 ns |    217.037 ns |  4.76 |    0.04 |       - |     - |     - |         - |
|   Hyperlinq |      .NET 4.8 |      .NET 4.8 |     1 |    282.492 ns |   1.4349 ns |   1.2720 ns |    282.780 ns |  6.20 |    0.03 |       - |     - |     - |         - |
|     ForLoop | .NET Core 3.1 | .NET Core 3.1 |     1 |     36.081 ns |   0.1598 ns |   0.1248 ns |     36.094 ns |  0.79 |    0.01 |  0.0803 |     - |     - |     168 B |
| ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     1 |     39.010 ns |   0.2404 ns |   0.2131 ns |     38.995 ns |  0.86 |    0.01 |  0.0803 |     - |     - |     168 B |
|        Linq | .NET Core 3.1 | .NET Core 3.1 |     1 |     91.282 ns |   0.4940 ns |   0.4379 ns |     91.158 ns |  2.00 |    0.01 |  0.1529 |     - |     - |     320 B |
|  LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     1 |      6.883 ns |   0.0485 ns |   0.0454 ns |      6.873 ns |  0.15 |    0.00 |       - |     - |     - |         - |
|  StructLinq | .NET Core 3.1 | .NET Core 3.1 |     1 |    163.443 ns |   1.4191 ns |   1.2580 ns |    163.493 ns |  3.59 |    0.03 |       - |     - |     - |         - |
|   Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |     1 |    172.683 ns |   0.7042 ns |   0.6587 ns |    172.611 ns |  3.79 |    0.02 |       - |     - |     - |         - |
|     ForLoop | .NET Core 5.0 | .NET Core 5.0 |     1 |     34.427 ns |   0.4549 ns |   0.3799 ns |     34.345 ns |  0.76 |    0.01 |  0.0842 |     - |     - |     176 B |
| ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     1 |     40.867 ns |   0.6470 ns |   0.5736 ns |     40.627 ns |  0.90 |    0.01 |  0.0842 |     - |     - |     176 B |
|        Linq | .NET Core 5.0 | .NET Core 5.0 |     1 |     94.874 ns |   0.6454 ns |   0.5721 ns |     94.865 ns |  2.08 |    0.02 |  0.1529 |     - |     - |     320 B |
|  LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     1 |      8.120 ns |   0.0400 ns |   0.0313 ns |      8.124 ns |  0.18 |    0.00 |       - |     - |     - |         - |
|  StructLinq | .NET Core 5.0 | .NET Core 5.0 |     1 |    124.425 ns |   0.9644 ns |   0.8549 ns |    124.498 ns |  2.73 |    0.02 |       - |     - |     - |         - |
|   Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |     1 |    140.793 ns |   0.8965 ns |   0.7947 ns |    140.695 ns |  3.09 |    0.03 |       - |     - |     - |         - |
|             |               |               |       |               |             |             |               |       |         |         |       |       |           |
|     **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |    **10** |    **290.231 ns** |   **1.1209 ns** |   **0.9936 ns** |    **290.001 ns** |  **1.00** |    **0.00** |  **0.3171** |     **-** |     **-** |     **666 B** |
| ForeachLoop |      .NET 4.8 |      .NET 4.8 |    10 |    292.561 ns |   2.2157 ns |   2.0725 ns |    292.238 ns |  1.01 |    0.01 |  0.3171 |     - |     - |     666 B |
|        Linq |      .NET 4.8 |      .NET 4.8 |    10 |    371.718 ns |   1.9404 ns |   1.6203 ns |    371.915 ns |  1.28 |    0.01 |  0.3018 |     - |     - |     634 B |
|  LinqFaster |      .NET 4.8 |      .NET 4.8 |    10 |     98.448 ns |   0.5018 ns |   0.4449 ns |     98.556 ns |  0.34 |    0.00 |       - |     - |     - |         - |
|  StructLinq |      .NET 4.8 |      .NET 4.8 |    10 |    599.665 ns |   3.8515 ns |   3.6027 ns |    599.666 ns |  2.07 |    0.02 |       - |     - |     - |         - |
|   Hyperlinq |      .NET 4.8 |      .NET 4.8 |    10 |    522.728 ns |   4.6361 ns |   3.8714 ns |    523.012 ns |  1.80 |    0.02 |       - |     - |     - |         - |
|     ForLoop | .NET Core 3.1 | .NET Core 3.1 |    10 |    243.427 ns |   1.7138 ns |   1.6031 ns |    243.317 ns |  0.84 |    0.01 |  0.3171 |     - |     - |     664 B |
| ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |    10 |    265.004 ns |   1.4406 ns |   1.3476 ns |    265.075 ns |  0.91 |    0.01 |  0.3171 |     - |     - |     664 B |
|        Linq | .NET Core 3.1 | .NET Core 3.1 |    10 |    348.252 ns |   1.6662 ns |   1.5585 ns |    348.724 ns |  1.20 |    0.01 |  0.2942 |     - |     - |     616 B |
|  LinqFaster | .NET Core 3.1 | .NET Core 3.1 |    10 |     85.472 ns |   0.1850 ns |   0.1545 ns |     85.529 ns |  0.29 |    0.00 |       - |     - |     - |         - |
|  StructLinq | .NET Core 3.1 | .NET Core 3.1 |    10 |    433.767 ns |   2.4051 ns |   2.1320 ns |    434.048 ns |  1.49 |    0.01 |       - |     - |     - |         - |
|   Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |    10 |    296.454 ns |   2.0701 ns |   1.9364 ns |    295.751 ns |  1.02 |    0.01 |       - |     - |     - |         - |
|     ForLoop | .NET Core 5.0 | .NET Core 5.0 |    10 |    195.835 ns |   1.0312 ns |   0.9142 ns |    195.766 ns |  0.67 |    0.00 |  0.3211 |     - |     - |     672 B |
| ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |    10 |    207.036 ns |   2.5421 ns |   2.2535 ns |    206.788 ns |  0.71 |    0.01 |  0.3211 |     - |     - |     672 B |
|        Linq | .NET Core 5.0 | .NET Core 5.0 |    10 |    357.537 ns |   2.0205 ns |   1.7911 ns |    356.774 ns |  1.23 |    0.01 |  0.2942 |     - |     - |     616 B |
|  LinqFaster | .NET Core 5.0 | .NET Core 5.0 |    10 |     62.979 ns |   0.4585 ns |   0.4065 ns |     62.914 ns |  0.22 |    0.00 |       - |     - |     - |         - |
|  StructLinq | .NET Core 5.0 | .NET Core 5.0 |    10 |    362.782 ns |   1.7784 ns |   1.6635 ns |    363.057 ns |  1.25 |    0.01 |       - |     - |     - |         - |
|   Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |    10 |    274.615 ns |   0.9771 ns |   0.9139 ns |    274.516 ns |  0.95 |    0.01 |       - |     - |     - |         - |
|             |               |               |       |               |             |             |               |       |         |         |       |       |           |
|     **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |  **1000** | **20,329.273 ns** | **121.4850 ns** | **107.6933 ns** | **20,301.007 ns** |  **1.00** |    **0.00** | **27.7710** |     **-** |     **-** |   **58880 B** |
| ForeachLoop |      .NET 4.8 |      .NET 4.8 |  1000 | 21,209.393 ns | 141.4869 ns | 118.1479 ns | 21,189.743 ns |  1.04 |    0.01 | 27.7710 |     - |     - |   58880 B |
|        Linq |      .NET 4.8 |      .NET 4.8 |  1000 | 26,274.702 ns | 188.3010 ns | 166.9239 ns | 26,332.103 ns |  1.29 |    0.01 | 15.8081 |     - |     - |   33234 B |
|  LinqFaster |      .NET 4.8 |      .NET 4.8 |  1000 |  8,954.816 ns |  48.7175 ns |  43.1868 ns |  8,964.476 ns |  0.44 |    0.00 |       - |     - |     - |         - |
|  StructLinq |      .NET 4.8 |      .NET 4.8 |  1000 | 19,865.074 ns |  70.9945 ns |  62.9348 ns | 19,887.544 ns |  0.98 |    0.01 |       - |     - |     - |         - |
|   Hyperlinq |      .NET 4.8 |      .NET 4.8 |  1000 | 31,507.219 ns | 162.2703 ns | 135.5031 ns | 31,548.468 ns |  1.55 |    0.01 |       - |     - |     - |         - |
|     ForLoop | .NET Core 3.1 | .NET Core 3.1 |  1000 | 18,178.968 ns | 134.6968 ns | 105.1624 ns | 18,168.361 ns |  0.89 |    0.00 | 27.7710 |     - |     - |   58664 B |
| ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |  1000 | 20,054.864 ns | 155.2841 ns | 137.6553 ns | 20,000.641 ns |  0.99 |    0.01 | 27.7710 |     - |     - |   58664 B |
|        Linq | .NET Core 3.1 | .NET Core 3.1 |  1000 | 24,444.948 ns | 115.1426 ns | 102.0709 ns | 24,429.736 ns |  1.20 |    0.01 | 15.7776 |     - |     - |   33112 B |
|  LinqFaster | .NET Core 3.1 | .NET Core 3.1 |  1000 |  7,712.089 ns |  50.9646 ns |  47.6723 ns |  7,701.659 ns |  0.38 |    0.00 |       - |     - |     - |         - |
|  StructLinq | .NET Core 3.1 | .NET Core 3.1 |  1000 | 16,562.512 ns |  46.1177 ns |  36.0057 ns | 16,568.541 ns |  0.82 |    0.00 |       - |     - |     - |         - |
|   Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |  1000 | 14,968.864 ns |  82.3949 ns |  73.0410 ns | 14,968.907 ns |  0.74 |    0.00 |       - |     - |     - |         - |
|     ForLoop | .NET Core 5.0 | .NET Core 5.0 |  1000 | 13,871.428 ns |  80.1013 ns |  66.8882 ns | 13,894.346 ns |  0.68 |    0.00 | 27.7710 |     - |     - |   58672 B |
| ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |  1000 | 14,949.802 ns | 108.3925 ns |  96.0871 ns | 14,958.936 ns |  0.74 |    0.01 | 27.7710 |     - |     - |   58672 B |
|        Linq | .NET Core 5.0 | .NET Core 5.0 |  1000 | 26,155.982 ns | 167.2077 ns | 156.4062 ns | 26,182.330 ns |  1.29 |    0.01 | 15.7776 |     - |     - |   33112 B |
|  LinqFaster | .NET Core 5.0 | .NET Core 5.0 |  1000 |  8,024.374 ns |  45.9844 ns |  43.0139 ns |  8,027.368 ns |  0.39 |    0.00 |       - |     - |     - |         - |
|  StructLinq | .NET Core 5.0 | .NET Core 5.0 |  1000 | 15,878.720 ns |  67.5988 ns |  59.9246 ns | 15,887.781 ns |  0.78 |    0.01 |       - |     - |     - |         - |
|   Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |  1000 | 15,479.278 ns | 117.7755 ns |  98.3478 ns | 15,436.287 ns |  0.76 |    0.01 |       - |     - |     - |         - |

Benchmarks with issues:
  ListDistinct.LinqFaster: .NET 4.8(Runtime=.NET 4.8) [Count=0]
  ListDistinct.LinqFaster: .NET Core 3.1(Runtime=.NET Core 3.1) [Count=0]
  ListDistinct.LinqFaster: .NET Core 5.0(Runtime=.NET Core 5.0) [Count=0]

## ListSelect

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET 4.8      : .NET Framework 4.8 (4.8.4180.0), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT


```
|               Method |           Job |       Runtime | Count |           Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |-------------- |-------------- |------ |---------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **0** |      **0.6117 ns** |  **0.0092 ns** |  **0.0086 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |     0 |      9.9432 ns |  0.0567 ns |  0.0502 ns | 16.26 |    0.28 |      - |     - |     - |         - |
|                 Linq |      .NET 4.8 |      .NET 4.8 |     0 |     37.2793 ns |  0.3481 ns |  0.2907 ns | 60.85 |    0.85 | 0.0382 |     - |     - |      80 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |     0 |     13.1640 ns |  0.1451 ns |  0.1287 ns | 21.52 |    0.37 | 0.0191 |     - |     - |      40 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |     21.5875 ns |  0.1130 ns |  0.1002 ns | 35.29 |    0.53 |      - |     - |     - |         - |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |     0 |     21.9375 ns |  0.0877 ns |  0.0820 ns | 35.87 |    0.53 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |      .NET 4.8 |      .NET 4.8 |     0 |     44.6610 ns |  0.1532 ns |  0.1358 ns | 73.02 |    1.11 |      - |     - |     - |         - |
|        Hyperlinq_For |      .NET 4.8 |      .NET 4.8 |     0 |     23.8692 ns |  0.0742 ns |  0.0694 ns | 39.03 |    0.52 |      - |     - |     - |         - |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |      0.3106 ns |  0.0073 ns |  0.0064 ns |  0.51 |    0.01 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |      3.4036 ns |  0.0297 ns |  0.0263 ns |  5.56 |    0.08 |      - |     - |     - |         - |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |     41.4209 ns |  0.3828 ns |  0.3581 ns | 67.73 |    1.16 | 0.0344 |     - |     - |      72 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     0 |      9.4246 ns |  0.0866 ns |  0.0768 ns | 15.41 |    0.26 | 0.0153 |     - |     - |      32 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |     21.9429 ns |  0.1764 ns |  0.1564 ns | 35.88 |    0.62 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |     0 |     22.8435 ns |  0.0610 ns |  0.0510 ns | 37.29 |    0.54 |      - |     - |     - |         - |
|    Hyperlinq_Foreach | .NET Core 3.1 | .NET Core 3.1 |     0 |     33.3859 ns |  0.1791 ns |  0.1675 ns | 54.59 |    0.73 |      - |     - |     - |         - |
|        Hyperlinq_For | .NET Core 3.1 | .NET Core 3.1 |     0 |     21.0318 ns |  0.1058 ns |  0.0990 ns | 34.39 |    0.53 |      - |     - |     - |         - |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |      0.5166 ns |  0.0103 ns |  0.0096 ns |  0.84 |    0.02 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |      2.7121 ns |  0.0360 ns |  0.0319 ns |  4.43 |    0.09 |      - |     - |     - |         - |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |     47.3074 ns |  0.2780 ns |  0.2600 ns | 77.35 |    1.11 | 0.0344 |     - |     - |      72 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     0 |     10.7033 ns |  0.0600 ns |  0.0532 ns | 17.50 |    0.25 | 0.0153 |     - |     - |      32 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |     15.7734 ns |  0.0864 ns |  0.0808 ns | 25.79 |    0.42 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |     0 |     15.6655 ns |  0.0439 ns |  0.0411 ns | 25.61 |    0.35 |      - |     - |     - |         - |
|    Hyperlinq_Foreach | .NET Core 5.0 | .NET Core 5.0 |     0 |     20.1382 ns |  0.0836 ns |  0.0698 ns | 32.87 |    0.50 |      - |     - |     - |         - |
|        Hyperlinq_For | .NET Core 5.0 | .NET Core 5.0 |     0 |      9.1289 ns |  0.0629 ns |  0.0557 ns | 14.93 |    0.26 |      - |     - |     - |         - |
|                      |               |               |       |                |            |            |       |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **1** |      **1.7776 ns** |  **0.0113 ns** |  **0.0094 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |     1 |     11.7756 ns |  0.0453 ns |  0.0402 ns |  6.63 |    0.04 |      - |     - |     - |         - |
|                 Linq |      .NET 4.8 |      .NET 4.8 |     1 |     45.2317 ns |  0.3000 ns |  0.2659 ns | 25.43 |    0.14 | 0.0382 |     - |     - |      80 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |     1 |     15.2020 ns |  0.1421 ns |  0.1329 ns |  8.55 |    0.11 | 0.0344 |     - |     - |      72 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |     1 |     25.0089 ns |  0.1243 ns |  0.1102 ns | 14.07 |    0.11 |      - |     - |     - |         - |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |     1 |     24.9541 ns |  0.1020 ns |  0.0955 ns | 14.05 |    0.10 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |      .NET 4.8 |      .NET 4.8 |     1 |     49.0970 ns |  0.1746 ns |  0.1548 ns | 27.61 |    0.17 |      - |     - |     - |         - |
|        Hyperlinq_For |      .NET 4.8 |      .NET 4.8 |     1 |     38.9351 ns |  0.2418 ns |  0.2019 ns | 21.90 |    0.16 |      - |     - |     - |         - |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |     1 |      0.8238 ns |  0.0105 ns |  0.0098 ns |  0.46 |    0.01 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     1 |      4.9743 ns |  0.0400 ns |  0.0334 ns |  2.80 |    0.03 |      - |     - |     - |         - |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |     1 |     50.6729 ns |  0.3005 ns |  0.2810 ns | 28.52 |    0.25 | 0.0344 |     - |     - |      72 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     1 |     14.9097 ns |  0.2801 ns |  0.2187 ns |  8.39 |    0.13 | 0.0306 |     - |     - |      64 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |     1 |     25.9886 ns |  0.0891 ns |  0.0833 ns | 14.63 |    0.09 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |     1 |     25.2415 ns |  0.0948 ns |  0.0886 ns | 14.20 |    0.10 |      - |     - |     - |         - |
|    Hyperlinq_Foreach | .NET Core 3.1 | .NET Core 3.1 |     1 |     36.0527 ns |  0.3763 ns |  0.3520 ns | 20.25 |    0.19 |      - |     - |     - |         - |
|        Hyperlinq_For | .NET Core 3.1 | .NET Core 3.1 |     1 |     26.0432 ns |  0.1217 ns |  0.1016 ns | 14.65 |    0.06 |      - |     - |     - |         - |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |     1 |      0.8660 ns |  0.0115 ns |  0.0102 ns |  0.49 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     1 |      5.6474 ns |  0.0206 ns |  0.0182 ns |  3.18 |    0.02 |      - |     - |     - |         - |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |     1 |     56.7344 ns |  0.5222 ns |  0.4360 ns | 31.92 |    0.32 | 0.0343 |     - |     - |      72 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     1 |     15.5253 ns |  0.0904 ns |  0.0801 ns |  8.74 |    0.05 | 0.0306 |     - |     - |      64 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |     1 |     19.3771 ns |  0.0738 ns |  0.0655 ns | 10.90 |    0.07 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |     1 |     18.3361 ns |  0.0813 ns |  0.0760 ns | 10.32 |    0.06 |      - |     - |     - |         - |
|    Hyperlinq_Foreach | .NET Core 5.0 | .NET Core 5.0 |     1 |     23.0380 ns |  0.0984 ns |  0.0821 ns | 12.96 |    0.07 |      - |     - |     - |         - |
|        Hyperlinq_For | .NET Core 5.0 | .NET Core 5.0 |     1 |     13.9948 ns |  0.0722 ns |  0.0675 ns |  7.87 |    0.05 |      - |     - |     - |         - |
|                      |               |               |       |                |            |            |       |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |    **10** |     **12.6233 ns** |  **0.0597 ns** |  **0.0529 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |    10 |     28.2430 ns |  0.1899 ns |  0.1684 ns |  2.24 |    0.01 |      - |     - |     - |         - |
|                 Linq |      .NET 4.8 |      .NET 4.8 |    10 |    122.1680 ns |  0.6961 ns |  0.6171 ns |  9.68 |    0.07 | 0.0381 |     - |     - |      80 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |    10 |     52.4893 ns |  0.3466 ns |  0.3072 ns |  4.16 |    0.03 | 0.0497 |     - |     - |     104 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |    10 |     43.0639 ns |  0.2073 ns |  0.1837 ns |  3.41 |    0.02 |      - |     - |     - |         - |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |    10 |     36.1001 ns |  0.1787 ns |  0.1672 ns |  2.86 |    0.02 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |      .NET 4.8 |      .NET 4.8 |    10 |     80.1813 ns |  0.6014 ns |  0.5626 ns |  6.35 |    0.06 |      - |     - |     - |         - |
|        Hyperlinq_For |      .NET 4.8 |      .NET 4.8 |    10 |    185.7425 ns |  0.7663 ns |  0.6793 ns | 14.71 |    0.06 |      - |     - |     - |         - |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |    10 |     10.9065 ns |  0.0595 ns |  0.0497 ns |  0.86 |    0.01 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |    10 |     22.3696 ns |  0.1285 ns |  0.1139 ns |  1.77 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |    10 |    133.7140 ns |  0.8955 ns |  0.7938 ns | 10.59 |    0.08 | 0.0343 |     - |     - |      72 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |    10 |     42.7970 ns |  0.5793 ns |  0.5419 ns |  3.39 |    0.04 | 0.0459 |     - |     - |      96 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |    10 |     43.0626 ns |  0.2021 ns |  0.1792 ns |  3.41 |    0.02 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |    10 |     36.6844 ns |  0.3421 ns |  0.3200 ns |  2.91 |    0.03 |      - |     - |     - |         - |
|    Hyperlinq_Foreach | .NET Core 3.1 | .NET Core 3.1 |    10 |     58.8366 ns |  0.2989 ns |  0.2650 ns |  4.66 |    0.03 |      - |     - |     - |         - |
|        Hyperlinq_For | .NET Core 3.1 | .NET Core 3.1 |    10 |     70.9163 ns |  0.3462 ns |  0.3239 ns |  5.62 |    0.04 |      - |     - |     - |         - |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |    10 |     10.8769 ns |  0.0611 ns |  0.0572 ns |  0.86 |    0.01 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |    10 |     24.6245 ns |  0.1445 ns |  0.1207 ns |  1.95 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |    10 |    130.3473 ns |  0.9376 ns |  0.8312 ns | 10.33 |    0.10 | 0.0343 |     - |     - |      72 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |    10 |     44.2054 ns |  0.3166 ns |  0.2644 ns |  3.50 |    0.03 | 0.0459 |     - |     - |      96 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |    10 |     36.3695 ns |  0.1491 ns |  0.1321 ns |  2.88 |    0.02 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |    10 |     30.1996 ns |  0.1203 ns |  0.1005 ns |  2.39 |    0.01 |      - |     - |     - |         - |
|    Hyperlinq_Foreach | .NET Core 5.0 | .NET Core 5.0 |    10 |     44.0373 ns |  0.1694 ns |  0.1585 ns |  3.49 |    0.02 |      - |     - |     - |         - |
|        Hyperlinq_For | .NET Core 5.0 | .NET Core 5.0 |    10 |     55.3962 ns |  0.3363 ns |  0.3145 ns |  4.39 |    0.03 |      - |     - |     - |         - |
|                      |               |               |       |                |            |            |       |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |  **1000** |  **1,021.4579 ns** |  **8.1802 ns** |  **7.6518 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |  1000 |  1,919.7480 ns | 12.0893 ns | 10.7168 ns |  1.88 |    0.02 |      - |     - |     - |         - |
|                 Linq |      .NET 4.8 |      .NET 4.8 |  1000 |  7,794.3960 ns | 65.4773 ns | 51.1204 ns |  7.62 |    0.07 | 0.0305 |     - |     - |      80 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |  1000 |  4,297.7389 ns | 23.9082 ns | 19.9644 ns |  4.20 |    0.02 | 1.9379 |     - |     - |    4080 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |  1000 |  2,691.9990 ns |  9.6834 ns |  9.0579 ns |  2.64 |    0.02 |      - |     - |     - |         - |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |  1000 |  1,447.9454 ns |  5.7270 ns |  4.7823 ns |  1.42 |    0.01 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |      .NET 4.8 |      .NET 4.8 |  1000 |  4,119.5863 ns | 27.6009 ns | 25.8179 ns |  4.03 |    0.04 |      - |     - |     - |         - |
|        Hyperlinq_For |      .NET 4.8 |      .NET 4.8 |  1000 | 15,335.4137 ns | 77.8537 ns | 72.8244 ns | 15.01 |    0.15 |      - |     - |     - |         - |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |  1000 |  1,011.1271 ns |  5.6942 ns |  5.3264 ns |  0.99 |    0.01 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |  1000 |  1,929.9825 ns |  9.4414 ns |  7.8840 ns |  1.89 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |  1000 |  7,911.9390 ns | 59.3636 ns | 55.5288 ns |  7.75 |    0.08 | 0.0305 |     - |     - |      72 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |  1000 |  3,361.0394 ns | 12.6955 ns | 11.2543 ns |  3.29 |    0.02 | 1.9379 |     - |     - |    4056 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |  1000 |  2,447.4760 ns |  7.2142 ns |  6.0242 ns |  2.39 |    0.02 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |  1000 |  1,447.7163 ns |  4.8722 ns |  4.5575 ns |  1.42 |    0.01 |      - |     - |     - |         - |
|    Hyperlinq_Foreach | .NET Core 3.1 | .NET Core 3.1 |  1000 |  2,738.0827 ns | 17.0905 ns | 15.1503 ns |  2.68 |    0.02 |      - |     - |     - |         - |
|        Hyperlinq_For | .NET Core 3.1 | .NET Core 3.1 |  1000 |  4,848.7661 ns | 10.1046 ns |  8.4378 ns |  4.74 |    0.03 |      - |     - |     - |         - |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |  1000 |  1,008.1971 ns |  4.3037 ns |  3.8152 ns |  0.99 |    0.01 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |  1000 |  2,157.6085 ns |  7.1139 ns |  6.3063 ns |  2.11 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |  1000 |  7,170.9509 ns | 30.8428 ns | 28.8504 ns |  7.02 |    0.07 | 0.0305 |     - |     - |      72 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |  1000 |  3,370.7287 ns | 24.0824 ns | 22.5267 ns |  3.30 |    0.03 | 1.9379 |     - |     - |    4056 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |  1000 |  2,687.1059 ns | 13.8512 ns | 12.9564 ns |  2.63 |    0.02 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |  1000 |  1,435.3060 ns |  6.5764 ns |  5.4916 ns |  1.40 |    0.01 |      - |     - |     - |         - |
|    Hyperlinq_Foreach | .NET Core 5.0 | .NET Core 5.0 |  1000 |  2,461.2815 ns | 14.8129 ns | 12.3695 ns |  2.41 |    0.02 |      - |     - |     - |         - |
|        Hyperlinq_For | .NET Core 5.0 | .NET Core 5.0 |  1000 |  4,604.7040 ns | 25.0395 ns | 22.1968 ns |  4.51 |    0.03 |      - |     - |     - |         - |

## ListSkipTakeSelect

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET 4.8      : .NET Framework 4.8 (4.8.4180.0), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT


```
|            Method |           Job |       Runtime | Skip | Count |           Mean |       Error |     StdDev |         Median |    Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------ |-------------- |-------------- |----- |------ |---------------:|------------:|-----------:|---------------:|---------:|--------:|-------:|------:|------:|----------:|
|           **ForLoop** |      **.NET 4.8** |      **.NET 4.8** | **1000** |     **0** |      **1.1139 ns** |   **0.0178 ns** |  **0.0148 ns** |      **1.1165 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|       ForeachLoop |      .NET 4.8 |      .NET 4.8 | 1000 |     0 |  3,251.9345 ns |  12.9821 ns | 10.8407 ns |  3,255.6076 ns | 2,919.96 |   42.12 | 0.0191 |     - |     - |      40 B |
|              Linq |      .NET 4.8 |      .NET 4.8 | 1000 |     0 |     64.9996 ns |   0.4007 ns |  0.3552 ns |     65.0220 ns |    58.38 |    0.96 | 0.0918 |     - |     - |     193 B |
| Hyperlinq_Foreach |      .NET 4.8 |      .NET 4.8 | 1000 |     0 |     50.6239 ns |   0.2929 ns |  0.2597 ns |     50.6807 ns |    45.44 |    0.67 |      - |     - |     - |         - |
|     Hyperlinq_For |      .NET 4.8 |      .NET 4.8 | 1000 |     0 |     29.0106 ns |   0.1920 ns |  0.1603 ns |     29.0235 ns |    26.05 |    0.36 |      - |     - |     - |         - |
|           ForLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |     0 |      0.3163 ns |   0.0175 ns |  0.0146 ns |      0.3120 ns |     0.28 |    0.01 |      - |     - |     - |         - |
|       ForeachLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |     0 |  3,280.2729 ns |  19.4812 ns | 18.2227 ns |  3,272.6429 ns | 2,943.67 |   42.62 | 0.0191 |     - |     - |      40 B |
|              Linq | .NET Core 3.1 | .NET Core 3.1 | 1000 |     0 |     42.6838 ns |   0.3270 ns |  0.2899 ns |     42.7202 ns |    38.35 |    0.55 | 0.0229 |     - |     - |      48 B |
| Hyperlinq_Foreach | .NET Core 3.1 | .NET Core 3.1 | 1000 |     0 |     35.8412 ns |   0.7326 ns |  1.1831 ns |     35.1171 ns |    33.48 |    0.46 |      - |     - |     - |         - |
|     Hyperlinq_For | .NET Core 3.1 | .NET Core 3.1 | 1000 |     0 |     24.8191 ns |   0.0658 ns |  0.0550 ns |     24.8244 ns |    22.29 |    0.30 |      - |     - |     - |         - |
|           ForLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |     0 |      0.3239 ns |   0.0153 ns |  0.0128 ns |      0.3256 ns |     0.29 |    0.01 |      - |     - |     - |         - |
|       ForeachLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |     0 |  3,255.9611 ns |  14.7455 ns | 13.0715 ns |  3,256.0913 ns | 2,923.53 |   33.82 | 0.0191 |     - |     - |      40 B |
|              Linq | .NET Core 5.0 | .NET Core 5.0 | 1000 |     0 |     46.3840 ns |   0.2934 ns |  0.2601 ns |     46.4295 ns |    41.64 |    0.61 | 0.0229 |     - |     - |      48 B |
| Hyperlinq_Foreach | .NET Core 5.0 | .NET Core 5.0 | 1000 |     0 |     30.9507 ns |   0.1292 ns |  0.1209 ns |     31.0018 ns |    27.77 |    0.38 |      - |     - |     - |         - |
|     Hyperlinq_For | .NET Core 5.0 | .NET Core 5.0 | 1000 |     0 |     19.7202 ns |   0.0937 ns |  0.0876 ns |     19.7101 ns |    17.70 |    0.23 |      - |     - |     - |         - |
|                   |               |               |      |       |                |             |            |                |          |         |        |       |       |           |
|           **ForLoop** |      **.NET 4.8** |      **.NET 4.8** | **1000** |     **1** |      **1.7830 ns** |   **0.0138 ns** |  **0.0123 ns** |      **1.7781 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|       ForeachLoop |      .NET 4.8 |      .NET 4.8 | 1000 |     1 |  3,278.8430 ns |  17.7474 ns | 16.6009 ns |  3,280.9727 ns | 1,838.75 |   17.97 | 0.0191 |     - |     - |      40 B |
|              Linq |      .NET 4.8 |      .NET 4.8 | 1000 |     1 |  3,930.5248 ns |  25.8688 ns | 24.1977 ns |  3,934.2842 ns | 2,205.61 |   15.42 | 0.1068 |     - |     - |     233 B |
| Hyperlinq_Foreach |      .NET 4.8 |      .NET 4.8 | 1000 |     1 |     54.5853 ns |   0.1908 ns |  0.1692 ns |     54.5092 ns |    30.62 |    0.23 |      - |     - |     - |         - |
|     Hyperlinq_For |      .NET 4.8 |      .NET 4.8 | 1000 |     1 |     44.7185 ns |   0.2635 ns |  0.2336 ns |     44.7154 ns |    25.08 |    0.26 |      - |     - |     - |         - |
|           ForLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |     1 |      0.4620 ns |   0.0092 ns |  0.0081 ns |      0.4644 ns |     0.26 |    0.00 |      - |     - |     - |         - |
|       ForeachLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |     1 |  3,525.8887 ns |  18.7112 ns | 16.5870 ns |  3,528.5637 ns | 1,977.57 |   16.21 | 0.0191 |     - |     - |      40 B |
|              Linq | .NET Core 3.1 | .NET Core 3.1 | 1000 |     1 |     89.3723 ns |   0.6584 ns |  0.6159 ns |     89.3369 ns |    50.10 |    0.48 | 0.0726 |     - |     - |     152 B |
| Hyperlinq_Foreach | .NET Core 3.1 | .NET Core 3.1 | 1000 |     1 |     38.5170 ns |   0.1018 ns |  0.0952 ns |     38.4876 ns |    21.60 |    0.17 |      - |     - |     - |         - |
|     Hyperlinq_For | .NET Core 3.1 | .NET Core 3.1 | 1000 |     1 |     30.1077 ns |   0.2443 ns |  0.2285 ns |     30.1368 ns |    16.88 |    0.20 |      - |     - |     - |         - |
|           ForLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |     1 |      0.5516 ns |   0.0145 ns |  0.0136 ns |      0.5509 ns |     0.31 |    0.01 |      - |     - |     - |         - |
|       ForeachLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |     1 |  3,259.3586 ns |  14.1396 ns | 13.2262 ns |  3,256.5235 ns | 1,829.15 |   12.84 | 0.0191 |     - |     - |      40 B |
|              Linq | .NET Core 5.0 | .NET Core 5.0 | 1000 |     1 |     91.7539 ns |   0.3428 ns |  0.2863 ns |     91.6655 ns |    51.41 |    0.40 | 0.0726 |     - |     - |     152 B |
| Hyperlinq_Foreach | .NET Core 5.0 | .NET Core 5.0 | 1000 |     1 |     35.3664 ns |   0.1858 ns |  0.1552 ns |     35.3129 ns |    19.82 |    0.19 |      - |     - |     - |         - |
|     Hyperlinq_For | .NET Core 5.0 | .NET Core 5.0 | 1000 |     1 |     24.5675 ns |   0.0843 ns |  0.0747 ns |     24.5606 ns |    13.78 |    0.10 |      - |     - |     - |         - |
|                   |               |               |      |       |                |             |            |                |          |         |        |       |       |           |
|           **ForLoop** |      **.NET 4.8** |      **.NET 4.8** | **1000** |    **10** |     **10.7387 ns** |   **0.0820 ns** |  **0.0727 ns** |     **10.7247 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|       ForeachLoop |      .NET 4.8 |      .NET 4.8 | 1000 |    10 |  3,289.2149 ns |  15.6093 ns | 13.8372 ns |  3,291.4732 ns |   306.31 |    2.67 | 0.0191 |     - |     - |      40 B |
|              Linq |      .NET 4.8 |      .NET 4.8 | 1000 |    10 |  4,155.2233 ns |  25.1752 ns | 21.0225 ns |  4,152.8214 ns |   387.14 |    3.21 | 0.1068 |     - |     - |     233 B |
| Hyperlinq_Foreach |      .NET 4.8 |      .NET 4.8 | 1000 |    10 |     91.0879 ns |   0.7665 ns |  0.6795 ns |     90.9263 ns |     8.48 |    0.10 |      - |     - |     - |         - |
|     Hyperlinq_For |      .NET 4.8 |      .NET 4.8 | 1000 |    10 |    190.7996 ns |   1.1869 ns |  0.9911 ns |    190.3625 ns |    17.78 |    0.18 |      - |     - |     - |         - |
|           ForLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |    10 |      8.0082 ns |   0.0980 ns |  0.0917 ns |      8.0287 ns |     0.74 |    0.01 |      - |     - |     - |         - |
|       ForeachLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |    10 |  3,551.9033 ns |  14.0841 ns | 12.4852 ns |  3,554.3320 ns |   330.77 |    2.19 | 0.0191 |     - |     - |      40 B |
|              Linq | .NET Core 3.1 | .NET Core 3.1 | 1000 |    10 |    181.0651 ns |   0.8184 ns |  0.6834 ns |    181.0443 ns |    16.87 |    0.13 | 0.0725 |     - |     - |     152 B |
| Hyperlinq_Foreach | .NET Core 3.1 | .NET Core 3.1 | 1000 |    10 |     59.5701 ns |   0.3120 ns |  0.2766 ns |     59.4589 ns |     5.55 |    0.05 |      - |     - |     - |         - |
|     Hyperlinq_For | .NET Core 3.1 | .NET Core 3.1 | 1000 |    10 |     74.2371 ns |   0.4168 ns |  0.3695 ns |     74.2758 ns |     6.91 |    0.06 |      - |     - |     - |         - |
|           ForLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |    10 |      8.1168 ns |   0.0587 ns |  0.0458 ns |      8.1279 ns |     0.76 |    0.01 |      - |     - |     - |         - |
|       ForeachLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |    10 |  3,280.9615 ns |  14.0497 ns | 12.4547 ns |  3,276.6352 ns |   305.54 |    1.91 | 0.0191 |     - |     - |      40 B |
|              Linq | .NET Core 5.0 | .NET Core 5.0 | 1000 |    10 |    187.1908 ns |   0.6413 ns |  0.5998 ns |    187.1117 ns |    17.42 |    0.11 | 0.0725 |     - |     - |     152 B |
| Hyperlinq_Foreach | .NET Core 5.0 | .NET Core 5.0 | 1000 |    10 |     54.9510 ns |   0.1957 ns |  0.1735 ns |     55.0092 ns |     5.12 |    0.04 |      - |     - |     - |         - |
|     Hyperlinq_For | .NET Core 5.0 | .NET Core 5.0 | 1000 |    10 |     66.7397 ns |   0.2902 ns |  0.2714 ns |     66.6541 ns |     6.21 |    0.05 |      - |     - |     - |         - |
|                   |               |               |      |       |                |             |            |                |          |         |        |       |       |           |
|           **ForLoop** |      **.NET 4.8** |      **.NET 4.8** | **1000** |  **1000** |    **825.3137 ns** |   **6.9707 ns** |  **6.1794 ns** |    **824.3526 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|       ForeachLoop |      .NET 4.8 |      .NET 4.8 | 1000 |  1000 |  6,207.9947 ns |  23.6943 ns | 21.0044 ns |  6,210.3161 ns |     7.52 |    0.06 | 0.0153 |     - |     - |      40 B |
|              Linq |      .NET 4.8 |      .NET 4.8 | 1000 |  1000 | 26,453.2030 ns | 102.0786 ns | 90.4900 ns | 26,426.5472 ns |    32.05 |    0.26 | 0.0916 |     - |     - |     233 B |
| Hyperlinq_Foreach |      .NET 4.8 |      .NET 4.8 | 1000 |  1000 |  4,116.4642 ns |  32.1626 ns | 28.5113 ns |  4,107.7301 ns |     4.99 |    0.06 |      - |     - |     - |         - |
|     Hyperlinq_For |      .NET 4.8 |      .NET 4.8 | 1000 |  1000 | 15,422.9936 ns |  72.9472 ns | 68.2348 ns | 15,423.4558 ns |    18.68 |    0.15 |      - |     - |     - |         - |
|           ForLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |  1000 |    800.8970 ns |   2.2699 ns |  1.8955 ns |    800.5626 ns |     0.97 |    0.01 |      - |     - |     - |         - |
|       ForeachLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |  1000 |  6,783.8298 ns |  27.2161 ns | 24.1264 ns |  6,779.1294 ns |     8.22 |    0.07 | 0.0153 |     - |     - |      40 B |
|              Linq | .NET Core 3.1 | .NET Core 3.1 | 1000 |  1000 |  9,009.2503 ns |  38.4020 ns | 32.0674 ns |  9,013.0783 ns |    10.92 |    0.10 | 0.0610 |     - |     - |     152 B |
| Hyperlinq_Foreach | .NET Core 3.1 | .NET Core 3.1 | 1000 |  1000 |  2,463.1435 ns |   8.3822 ns |  7.4306 ns |  2,461.9781 ns |     2.98 |    0.02 |      - |     - |     - |         - |
|     Hyperlinq_For | .NET Core 3.1 | .NET Core 3.1 | 1000 |  1000 |  4,879.7206 ns |  28.8197 ns | 25.5479 ns |  4,882.8522 ns |     5.91 |    0.05 |      - |     - |     - |         - |
|           ForLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |  1000 |    678.9013 ns |   3.7698 ns |  3.5262 ns |    678.1669 ns |     0.82 |    0.01 |      - |     - |     - |         - |
|       ForeachLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |  1000 |  6,487.5496 ns |  23.9917 ns | 21.2680 ns |  6,491.2037 ns |     7.86 |    0.06 | 0.0153 |     - |     - |      40 B |
|              Linq | .NET Core 5.0 | .NET Core 5.0 | 1000 |  1000 |  9,450.1722 ns |  54.1221 ns | 47.9779 ns |  9,446.8422 ns |    11.45 |    0.11 | 0.0610 |     - |     - |     152 B |
| Hyperlinq_Foreach | .NET Core 5.0 | .NET Core 5.0 | 1000 |  1000 |  2,198.0330 ns |  14.9104 ns | 12.4509 ns |  2,201.0483 ns |     2.66 |    0.03 |      - |     - |     - |         - |
|     Hyperlinq_For | .NET Core 5.0 | .NET Core 5.0 | 1000 |  1000 |  4,631.7740 ns |  53.7219 ns | 50.2515 ns |  4,616.1354 ns |     5.62 |    0.08 |      - |     - |     - |         - |

## ListSkipTakeWhere

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET 4.8      : .NET Framework 4.8 (4.8.4180.0), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT


```
|      Method |           Job |       Runtime | Skip | Count |           Mean |       Error |      StdDev |    Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |-------------- |-------------- |----- |------ |---------------:|------------:|------------:|---------:|--------:|-------:|------:|------:|----------:|
|     **ForLoop** |      **.NET 4.8** |      **.NET 4.8** | **1000** |     **0** |      **0.8711 ns** |   **0.0162 ns** |   **0.0135 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
| ForeachLoop |      .NET 4.8 |      .NET 4.8 | 1000 |     0 |  3,257.2489 ns |  18.5798 ns |  15.5150 ns | 3,740.08 |   61.69 | 0.0191 |     - |     - |      40 B |
|        Linq |      .NET 4.8 |      .NET 4.8 | 1000 |     0 |     66.0312 ns |   0.4833 ns |   0.4036 ns |    75.82 |    1.30 | 0.0880 |     - |     - |     185 B |
|   Hyperlinq |      .NET 4.8 |      .NET 4.8 | 1000 |     0 |     50.7311 ns |   0.4068 ns |   0.3397 ns |    58.25 |    1.07 |      - |     - |     - |         - |
|     ForLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |     0 |      0.3135 ns |   0.0170 ns |   0.0151 ns |     0.36 |    0.02 |      - |     - |     - |         - |
| ForeachLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |     0 |  3,275.0881 ns |  15.3618 ns |  11.9935 ns | 3,761.76 |   63.48 | 0.0191 |     - |     - |      40 B |
|        Linq | .NET Core 3.1 | .NET Core 3.1 | 1000 |     0 |     64.7247 ns |   0.2666 ns |   0.2364 ns |    74.30 |    1.16 | 0.0497 |     - |     - |     104 B |
|   Hyperlinq | .NET Core 3.1 | .NET Core 3.1 | 1000 |     0 |     35.9104 ns |   0.2831 ns |   0.2510 ns |    41.25 |    0.62 |      - |     - |     - |         - |
|     ForLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |     0 |      0.2807 ns |   0.0085 ns |   0.0079 ns |     0.32 |    0.01 |      - |     - |     - |         - |
| ForeachLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |     0 |  3,487.2658 ns |  16.4131 ns |  14.5498 ns | 4,003.49 |   57.77 | 0.0191 |     - |     - |      40 B |
|        Linq | .NET Core 5.0 | .NET Core 5.0 | 1000 |     0 |     73.9679 ns |   0.4942 ns |   0.4381 ns |    84.90 |    1.64 | 0.0497 |     - |     - |     104 B |
|   Hyperlinq | .NET Core 5.0 | .NET Core 5.0 | 1000 |     0 |     32.2801 ns |   0.0867 ns |   0.0811 ns |    37.06 |    0.57 |      - |     - |     - |         - |
|             |               |               |      |       |                |             |             |          |         |        |       |       |           |
|     **ForLoop** |      **.NET 4.8** |      **.NET 4.8** | **1000** |     **1** |      **1.8590 ns** |   **0.0144 ns** |   **0.0134 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
| ForeachLoop |      .NET 4.8 |      .NET 4.8 | 1000 |     1 |  3,273.1671 ns |  19.7007 ns |  16.4510 ns | 1,761.41 |    9.93 | 0.0191 |     - |     - |      40 B |
|        Linq |      .NET 4.8 |      .NET 4.8 | 1000 |     1 |  3,744.9892 ns |  23.9499 ns |  22.4028 ns | 2,014.66 |   19.09 | 0.1068 |     - |     - |     225 B |
|   Hyperlinq |      .NET 4.8 |      .NET 4.8 | 1000 |     1 |     56.1399 ns |   0.1999 ns |   0.1870 ns |    30.20 |    0.26 |      - |     - |     - |         - |
|     ForLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |     1 |      0.5213 ns |   0.0088 ns |   0.0078 ns |     0.28 |    0.01 |      - |     - |     - |         - |
| ForeachLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |     1 |  3,294.3695 ns |  24.4016 ns |  20.3765 ns | 1,772.85 |   16.33 | 0.0191 |     - |     - |      40 B |
|        Linq | .NET Core 3.1 | .NET Core 3.1 | 1000 |     1 |     99.7683 ns |   0.7353 ns |   0.6878 ns |    53.67 |    0.60 | 0.0726 |     - |     - |     152 B |
|   Hyperlinq | .NET Core 3.1 | .NET Core 3.1 | 1000 |     1 |     40.9728 ns |   0.2441 ns |   0.2038 ns |    22.05 |    0.18 |      - |     - |     - |         - |
|     ForLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |     1 |      0.5283 ns |   0.0142 ns |   0.0126 ns |     0.28 |    0.01 |      - |     - |     - |         - |
| ForeachLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |     1 |  3,519.5673 ns |  17.2384 ns |  14.3949 ns | 1,894.07 |   18.58 | 0.0191 |     - |     - |      40 B |
|        Linq | .NET Core 5.0 | .NET Core 5.0 | 1000 |     1 |    108.7948 ns |   0.5126 ns |   0.4544 ns |    58.53 |    0.49 | 0.0726 |     - |     - |     152 B |
|   Hyperlinq | .NET Core 5.0 | .NET Core 5.0 | 1000 |     1 |     37.2219 ns |   0.1473 ns |   0.1306 ns |    20.03 |    0.18 |      - |     - |     - |         - |
|             |               |               |      |       |                |             |             |          |         |        |       |       |           |
|     **ForLoop** |      **.NET 4.8** |      **.NET 4.8** | **1000** |    **10** |     **14.0506 ns** |   **0.1046 ns** |   **0.0873 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
| ForeachLoop |      .NET 4.8 |      .NET 4.8 | 1000 |    10 |  3,302.7016 ns |  14.8210 ns |  13.8636 ns |   235.21 |    1.80 | 0.0191 |     - |     - |      40 B |
|        Linq |      .NET 4.8 |      .NET 4.8 | 1000 |    10 |  3,946.8493 ns |  23.5802 ns |  20.9033 ns |   280.98 |    2.21 | 0.1068 |     - |     - |     225 B |
|   Hyperlinq |      .NET 4.8 |      .NET 4.8 | 1000 |    10 |     96.0844 ns |   0.4170 ns |   0.3696 ns |     6.84 |    0.04 |      - |     - |     - |         - |
|     ForLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |    10 |     12.0737 ns |   0.0298 ns |   0.0248 ns |     0.86 |    0.01 |      - |     - |     - |         - |
| ForeachLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |    10 |  3,311.9876 ns |  14.8328 ns |  13.1489 ns |   235.75 |    1.68 | 0.0191 |     - |     - |      40 B |
|        Linq | .NET Core 3.1 | .NET Core 3.1 | 1000 |    10 |    223.1142 ns |   1.6986 ns |   1.5058 ns |    15.87 |    0.12 | 0.0725 |     - |     - |     152 B |
|   Hyperlinq | .NET Core 3.1 | .NET Core 3.1 | 1000 |    10 |     65.5176 ns |   0.3165 ns |   0.2961 ns |     4.66 |    0.04 |      - |     - |     - |         - |
|     ForLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |    10 |      8.5689 ns |   0.0421 ns |   0.0373 ns |     0.61 |    0.00 |      - |     - |     - |         - |
| ForeachLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |    10 |  3,442.0837 ns |  16.2388 ns |  12.6782 ns |   245.09 |    1.66 | 0.0191 |     - |     - |      40 B |
|        Linq | .NET Core 5.0 | .NET Core 5.0 | 1000 |    10 |    221.9827 ns |   1.2069 ns |   1.0078 ns |    15.80 |    0.12 | 0.0725 |     - |     - |     152 B |
|   Hyperlinq | .NET Core 5.0 | .NET Core 5.0 | 1000 |    10 |     59.3772 ns |   0.2790 ns |   0.2473 ns |     4.23 |    0.03 |      - |     - |     - |         - |
|             |               |               |      |       |                |             |             |          |         |        |       |       |           |
|     **ForLoop** |      **.NET 4.8** |      **.NET 4.8** | **1000** |  **1000** |  **1,375.4687 ns** |   **6.0757 ns** |   **5.3859 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
| ForeachLoop |      .NET 4.8 |      .NET 4.8 | 1000 |  1000 |  6,521.9497 ns |  40.5115 ns |  35.9124 ns |     4.74 |    0.04 | 0.0153 |     - |     - |      40 B |
|        Linq |      .NET 4.8 |      .NET 4.8 | 1000 |  1000 | 24,105.4899 ns | 185.3003 ns | 164.2639 ns |    17.53 |    0.13 | 0.0916 |     - |     - |     225 B |
|   Hyperlinq |      .NET 4.8 |      .NET 4.8 | 1000 |  1000 |  4,799.1452 ns |  21.6530 ns |  19.1948 ns |     3.49 |    0.02 |      - |     - |     - |         - |
|     ForLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |  1000 |  1,196.0486 ns |   3.7445 ns |   3.3194 ns |     0.87 |    0.00 |      - |     - |     - |         - |
| ForeachLoop | .NET Core 3.1 | .NET Core 3.1 | 1000 |  1000 |  6,775.4441 ns |  37.5358 ns |  33.2745 ns |     4.93 |    0.03 | 0.0153 |     - |     - |      40 B |
|        Linq | .NET Core 3.1 | .NET Core 3.1 | 1000 |  1000 | 11,965.0543 ns |  47.5766 ns |  42.1754 ns |     8.70 |    0.05 | 0.0610 |     - |     - |     152 B |
|   Hyperlinq | .NET Core 3.1 | .NET Core 3.1 | 1000 |  1000 |  3,404.4501 ns |  11.6874 ns |   9.1247 ns |     2.48 |    0.01 |      - |     - |     - |         - |
|     ForLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |  1000 |    817.1600 ns |   4.1903 ns |   3.7146 ns |     0.59 |    0.00 |      - |     - |     - |         - |
| ForeachLoop | .NET Core 5.0 | .NET Core 5.0 | 1000 |  1000 |  7,392.3977 ns |  26.9119 ns |  23.8567 ns |     5.37 |    0.03 | 0.0153 |     - |     - |      40 B |
|        Linq | .NET Core 5.0 | .NET Core 5.0 | 1000 |  1000 | 11,662.5374 ns |  48.5036 ns |  42.9972 ns |     8.48 |    0.05 | 0.0610 |     - |     - |     152 B |
|   Hyperlinq | .NET Core 5.0 | .NET Core 5.0 | 1000 |  1000 |  3,507.7941 ns |  13.2006 ns |  11.7020 ns |     2.55 |    0.01 |      - |     - |     - |         - |

## ListWhere

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET 4.8      : .NET Framework 4.8 (4.8.4180.0), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT


```
|               Method |           Job |       Runtime | Count |          Mean |      Error |     StdDev |        Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |-------------- |-------------- |------ |--------------:|-----------:|-----------:|--------------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **0** |     **0.6531 ns** |  **0.0126 ns** |  **0.0118 ns** |     **0.6576 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |     0 |    10.1011 ns |  0.0647 ns |  0.0541 ns |    10.1061 ns | 15.49 |    0.33 |      - |     - |     - |         - |
|                 Linq |      .NET 4.8 |      .NET 4.8 |     0 |    36.8683 ns |  0.2110 ns |  0.1871 ns |    36.8909 ns | 56.49 |    1.16 | 0.0344 |     - |     - |      72 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |     0 |    12.2604 ns |  0.0639 ns |  0.0567 ns |    12.2643 ns | 18.78 |    0.36 | 0.0191 |     - |     - |      40 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |    21.5973 ns |  0.0938 ns |  0.0877 ns |    21.5919 ns | 33.08 |    0.61 |      - |     - |     - |         - |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |     0 |    22.3568 ns |  0.2946 ns |  0.2755 ns |    22.2576 ns | 34.24 |    0.73 |      - |     - |     - |         - |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |     0 |    50.8796 ns |  1.0471 ns |  1.6608 ns |    50.9530 ns | 76.46 |    2.85 |      - |     - |     - |         - |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |     0.3295 ns |  0.0420 ns |  0.0561 ns |     0.3246 ns |  0.52 |    0.08 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |     3.6189 ns |  0.1077 ns |  0.2929 ns |     3.4730 ns |  6.26 |    0.33 |      - |     - |     - |         - |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |    43.7514 ns |  0.2856 ns |  0.2532 ns |    43.7062 ns | 67.03 |    1.24 | 0.0344 |     - |     - |      72 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     0 |     9.2291 ns |  0.2052 ns |  0.1920 ns |     9.2081 ns | 14.14 |    0.37 | 0.0153 |     - |     - |      32 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |    22.0392 ns |  0.2030 ns |  0.1898 ns |    22.1344 ns | 33.76 |    0.74 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |     0 |    21.8282 ns |  0.0546 ns |  0.0456 ns |    21.8235 ns | 33.47 |    0.67 |      - |     - |     - |         - |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |     0 |    33.6240 ns |  0.2815 ns |  0.2634 ns |    33.6719 ns | 51.50 |    1.07 |      - |     - |     - |         - |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |     0.2438 ns |  0.0097 ns |  0.0086 ns |     0.2434 ns |  0.37 |    0.01 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |     2.7516 ns |  0.0257 ns |  0.0228 ns |     2.7427 ns |  4.22 |    0.09 |      - |     - |     - |         - |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |    46.5199 ns |  0.2083 ns |  0.1847 ns |    46.5949 ns | 71.27 |    1.44 | 0.0344 |     - |     - |      72 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     0 |     9.6085 ns |  0.0672 ns |  0.0628 ns |     9.6199 ns | 14.72 |    0.29 | 0.0153 |     - |     - |      32 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |    15.8031 ns |  0.0967 ns |  0.0905 ns |    15.8206 ns | 24.21 |    0.48 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |     0 |    15.7425 ns |  0.0464 ns |  0.0411 ns |    15.7406 ns | 24.12 |    0.48 |      - |     - |     - |         - |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |     0 |    20.8008 ns |  0.0766 ns |  0.0639 ns |    20.8098 ns | 31.90 |    0.65 |      - |     - |     - |         - |
|                      |               |               |       |               |            |            |               |       |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **1** |     **1.8040 ns** |  **0.0114 ns** |  **0.0101 ns** |     **1.8025 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |     1 |    11.8298 ns |  0.0441 ns |  0.0391 ns |    11.8375 ns |  6.56 |    0.04 |      - |     - |     - |         - |
|                 Linq |      .NET 4.8 |      .NET 4.8 |     1 |    43.8642 ns |  0.2480 ns |  0.2199 ns |    43.8050 ns | 24.32 |    0.15 | 0.0344 |     - |     - |      72 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |     1 |    26.8232 ns |  0.1308 ns |  0.1159 ns |    26.8469 ns | 14.87 |    0.11 | 0.0382 |     - |     - |      80 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |     1 |    26.0558 ns |  0.0921 ns |  0.0769 ns |    26.0518 ns | 14.44 |    0.09 |      - |     - |     - |         - |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |     1 |    24.8929 ns |  0.0891 ns |  0.0834 ns |    24.8932 ns | 13.80 |    0.08 |      - |     - |     - |         - |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |     1 |    50.9791 ns |  0.1727 ns |  0.1615 ns |    50.9674 ns | 28.25 |    0.18 |      - |     - |     - |         - |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |     1 |     0.8153 ns |  0.0104 ns |  0.0087 ns |     0.8172 ns |  0.45 |    0.01 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     1 |     5.0475 ns |  0.0257 ns |  0.0214 ns |     5.0428 ns |  2.80 |    0.02 |      - |     - |     - |         - |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |     1 |    46.9687 ns |  0.3601 ns |  0.3192 ns |    47.0382 ns | 26.04 |    0.18 | 0.0344 |     - |     - |      72 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     1 |    21.5701 ns |  0.2559 ns |  0.2394 ns |    21.4478 ns | 11.96 |    0.14 | 0.0344 |     - |     - |      72 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |     1 |    26.3072 ns |  0.1855 ns |  0.1645 ns |    26.3761 ns | 14.58 |    0.14 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |     1 |    25.7526 ns |  0.0984 ns |  0.0920 ns |    25.7539 ns | 14.28 |    0.09 |      - |     - |     - |         - |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |     1 |    39.2215 ns |  0.2203 ns |  0.1953 ns |    39.2049 ns | 21.74 |    0.19 |      - |     - |     - |         - |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |     1 |     0.9398 ns |  0.0153 ns |  0.0127 ns |     0.9425 ns |  0.52 |    0.01 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     1 |     5.2758 ns |  0.0282 ns |  0.0250 ns |     5.2729 ns |  2.92 |    0.02 |      - |     - |     - |         - |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |     1 |    52.6823 ns |  0.3240 ns |  0.3031 ns |    52.6627 ns | 29.20 |    0.23 | 0.0344 |     - |     - |      72 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     1 |    21.7645 ns |  0.2250 ns |  0.1879 ns |    21.7308 ns | 12.07 |    0.13 | 0.0344 |     - |     - |      72 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |     1 |    19.7240 ns |  0.0947 ns |  0.0886 ns |    19.7056 ns | 10.94 |    0.07 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |     1 |    18.7903 ns |  0.0512 ns |  0.0479 ns |    18.7873 ns | 10.42 |    0.06 |      - |     - |     - |         - |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |     1 |    25.3524 ns |  0.1059 ns |  0.0938 ns |    25.3758 ns | 14.05 |    0.09 |      - |     - |     - |         - |
|                      |               |               |       |               |            |            |               |       |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |    **10** |    **13.1314 ns** |  **0.0622 ns** |  **0.0582 ns** |    **13.1261 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |    10 |    30.0216 ns |  0.2535 ns |  0.2117 ns |    29.9273 ns |  2.29 |    0.02 |      - |     - |     - |         - |
|                 Linq |      .NET 4.8 |      .NET 4.8 |    10 |    99.7437 ns |  0.4089 ns |  0.3625 ns |    99.7259 ns |  7.60 |    0.05 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |    10 |    78.5755 ns |  0.5005 ns |  0.4437 ns |    78.4392 ns |  5.98 |    0.03 | 0.0650 |     - |     - |     136 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |    10 |    47.6778 ns |  0.1832 ns |  0.1713 ns |    47.6932 ns |  3.63 |    0.02 |      - |     - |     - |         - |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |    10 |    38.0835 ns |  0.1636 ns |  0.1531 ns |    38.1220 ns |  2.90 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |    10 |    84.9302 ns |  0.3628 ns |  0.3216 ns |    84.9192 ns |  6.47 |    0.05 |      - |     - |     - |         - |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |    10 |    12.9304 ns |  0.0387 ns |  0.0302 ns |    12.9389 ns |  0.99 |    0.01 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |    10 |    26.1837 ns |  0.1104 ns |  0.0862 ns |    26.2022 ns |  1.99 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |    10 |    97.4671 ns |  0.5533 ns |  0.5176 ns |    97.4590 ns |  7.42 |    0.05 | 0.0343 |     - |     - |      72 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |    10 |    68.6185 ns |  0.4483 ns |  0.4193 ns |    68.5036 ns |  5.23 |    0.04 | 0.0612 |     - |     - |     128 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |    10 |    49.2875 ns |  0.2694 ns |  0.2388 ns |    49.3179 ns |  3.75 |    0.02 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |    10 |    38.5268 ns |  0.1878 ns |  0.1568 ns |    38.5485 ns |  2.93 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |    10 |    64.7891 ns |  0.2601 ns |  0.2305 ns |    64.8003 ns |  4.93 |    0.02 |      - |     - |     - |         - |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |    10 |    10.7756 ns |  0.0606 ns |  0.0567 ns |    10.7856 ns |  0.82 |    0.01 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |    10 |    25.4520 ns |  0.1312 ns |  0.1227 ns |    25.4559 ns |  1.94 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |    10 |   106.9875 ns |  1.1299 ns |  0.8822 ns |   106.8798 ns |  8.15 |    0.07 | 0.0343 |     - |     - |      72 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |    10 |    64.5711 ns |  0.4358 ns |  0.3863 ns |    64.6347 ns |  4.92 |    0.03 | 0.0612 |     - |     - |     128 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |    10 |    40.9601 ns |  0.2111 ns |  0.1872 ns |    40.9642 ns |  3.12 |    0.02 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |    10 |    32.5365 ns |  0.1962 ns |  0.1638 ns |    32.5290 ns |  2.48 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |    10 |    52.8519 ns |  0.1856 ns |  0.1646 ns |    52.8675 ns |  4.02 |    0.02 |      - |     - |     - |         - |
|                      |               |               |       |               |            |            |               |       |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |  **1000** | **1,193.3456 ns** | **22.6125 ns** | **23.2214 ns** | **1,192.1995 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |  1000 | 1,897.9285 ns |  7.2734 ns |  6.4477 ns | 1,895.8702 ns |  1.59 |    0.03 |      - |     - |     - |         - |
|                 Linq |      .NET 4.8 |      .NET 4.8 |  1000 | 6,066.6459 ns | 32.4254 ns | 28.7443 ns | 6,071.2116 ns |  5.09 |    0.11 | 0.0305 |     - |     - |      72 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |  1000 | 3,707.8902 ns | 21.0753 ns | 18.6827 ns | 3,701.8995 ns |  3.11 |    0.07 | 2.0599 |     - |     - |    4325 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |  1000 | 2,890.6889 ns | 16.6843 ns | 14.7902 ns | 2,888.4680 ns |  2.43 |    0.05 |      - |     - |     - |         - |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |  1000 | 1,645.9286 ns |  9.1415 ns |  8.1037 ns | 1,644.9501 ns |  1.38 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |  1000 | 4,467.6523 ns | 20.0934 ns | 17.8123 ns | 4,467.7780 ns |  3.75 |    0.08 |      - |     - |     - |         - |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |  1000 | 1,204.6033 ns |  4.0981 ns |  3.8333 ns | 1,203.4157 ns |  1.01 |    0.02 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |  1000 | 2,274.9639 ns | 10.7181 ns | 10.0257 ns | 2,276.1246 ns |  1.91 |    0.04 |      - |     - |     - |         - |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |  1000 | 5,609.6903 ns | 24.7969 ns | 23.1951 ns | 5,600.4601 ns |  4.71 |    0.10 | 0.0305 |     - |     - |      72 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |  1000 | 3,176.0989 ns | 17.1568 ns | 16.0485 ns | 3,175.3967 ns |  2.67 |    0.06 | 2.0561 |     - |     - |    4304 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |  1000 | 3,122.5096 ns | 17.8500 ns | 14.9056 ns | 3,124.8867 ns |  2.63 |    0.06 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |  1000 | 1,511.0748 ns |  7.9219 ns |  7.0226 ns | 1,511.4596 ns |  1.27 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |  1000 | 3,521.0546 ns | 13.2973 ns | 12.4383 ns | 3,521.3554 ns |  2.96 |    0.06 |      - |     - |     - |         - |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |  1000 | 1,022.2736 ns |  5.6407 ns |  5.2763 ns | 1,023.0799 ns |  0.86 |    0.02 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |  1000 | 2,436.4164 ns | 12.4996 ns | 11.0806 ns | 2,435.1486 ns |  2.04 |    0.04 |      - |     - |     - |         - |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |  1000 | 6,210.7644 ns | 35.5288 ns | 33.2336 ns | 6,224.4896 ns |  5.21 |    0.11 | 0.0305 |     - |     - |      72 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |  1000 | 3,333.1584 ns | 15.1686 ns | 12.6665 ns | 3,332.3439 ns |  2.80 |    0.06 | 2.0561 |     - |     - |    4304 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |  1000 | 3,236.4087 ns | 16.2299 ns | 14.3874 ns | 3,231.6339 ns |  2.72 |    0.05 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |  1000 | 1,473.1590 ns |  5.3773 ns |  4.4903 ns | 1,473.4947 ns |  1.24 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |  1000 | 3,767.6128 ns | 17.4628 ns | 15.4804 ns | 3,765.6235 ns |  3.16 |    0.07 |      - |     - |     - |         - |

## ListWhereSelect

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET 4.8      : .NET Framework 4.8 (4.8.4180.0), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT


```
|               Method |           Job |       Runtime | Count |          Mean |      Error |     StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |-------------- |-------------- |------ |--------------:|-----------:|-----------:|-------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **0** |     **0.6552 ns** |  **0.0110 ns** |  **0.0092 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |     0 |    10.1660 ns |  0.0507 ns |  0.0474 ns |  15.51 |    0.22 |      - |     - |     - |         - |
|                 Linq |      .NET 4.8 |      .NET 4.8 |     0 |    67.0896 ns |  0.2865 ns |  0.2680 ns | 102.42 |    1.39 | 0.0726 |     - |     - |     152 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |     0 |     7.2799 ns |  0.0527 ns |  0.0440 ns |  11.11 |    0.17 | 0.0191 |     - |     - |      40 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |    41.7119 ns |  0.2159 ns |  0.2019 ns |  63.71 |    1.02 |      - |     - |     - |         - |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |     0 |    42.7249 ns |  0.1822 ns |  0.1704 ns |  65.21 |    0.96 |      - |     - |     - |         - |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |     0 |    61.9801 ns |  0.2162 ns |  0.1805 ns |  94.61 |    1.38 |      - |     - |     - |         - |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |     0.2510 ns |  0.0112 ns |  0.0099 ns |   0.38 |    0.01 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |     4.0077 ns |  0.1102 ns |  0.1269 ns |   6.09 |    0.24 |      - |     - |     - |         - |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |    69.6623 ns |  0.4859 ns |  0.4307 ns | 106.42 |    1.50 | 0.0726 |     - |     - |     152 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     0 |     8.5769 ns |  0.1947 ns |  0.2164 ns |  13.22 |    0.42 | 0.0153 |     - |     - |      32 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |    41.9512 ns |  0.2723 ns |  0.2547 ns |  64.05 |    1.02 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |     0 |    42.1850 ns |  0.1748 ns |  0.1635 ns |  64.41 |    0.82 |      - |     - |     - |         - |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |     0 |    41.7482 ns |  0.1418 ns |  0.1257 ns |  63.73 |    0.93 |      - |     - |     - |         - |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |     0.3329 ns |  0.0108 ns |  0.0096 ns |   0.51 |    0.01 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |     2.9623 ns |  0.0202 ns |  0.0189 ns |   4.52 |    0.08 |      - |     - |     - |         - |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |    74.9921 ns |  0.4982 ns |  0.4660 ns | 114.44 |    1.68 | 0.0726 |     - |     - |     152 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     0 |     8.8173 ns |  0.0863 ns |  0.0765 ns |  13.47 |    0.24 | 0.0153 |     - |     - |      32 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |    32.1739 ns |  0.2332 ns |  0.2182 ns |  49.06 |    0.63 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |     0 |    33.1874 ns |  0.1243 ns |  0.1102 ns |  50.68 |    0.69 |      - |     - |     - |         - |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |     0 |    28.5732 ns |  0.3274 ns |  0.2902 ns |  43.63 |    0.85 |      - |     - |     - |         - |
|                      |               |               |       |               |            |            |        |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **1** |     **1.7811 ns** |  **0.0149 ns** |  **0.0139 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |     1 |    11.8025 ns |  0.0934 ns |  0.0780 ns |   6.62 |    0.07 |      - |     - |     - |         - |
|                 Linq |      .NET 4.8 |      .NET 4.8 |     1 |    77.4765 ns |  0.5602 ns |  0.4966 ns |  43.47 |    0.51 | 0.0726 |     - |     - |     152 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |     1 |    24.4654 ns |  0.1299 ns |  0.1152 ns |  13.73 |    0.12 | 0.0382 |     - |     - |      80 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |     1 |    47.0262 ns |  0.2442 ns |  0.2284 ns |  26.40 |    0.27 |      - |     - |     - |         - |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |     1 |    45.5841 ns |  0.1891 ns |  0.1579 ns |  25.57 |    0.20 |      - |     - |     - |         - |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |     1 |    69.4126 ns |  0.3028 ns |  0.2832 ns |  38.97 |    0.37 |      - |     - |     - |         - |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |     1 |     0.9256 ns |  0.0110 ns |  0.0102 ns |   0.52 |    0.01 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     1 |     5.0537 ns |  0.0310 ns |  0.0275 ns |   2.84 |    0.03 |      - |     - |     - |         - |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |     1 |    83.8603 ns |  0.8748 ns |  0.8183 ns |  47.09 |    0.60 | 0.0726 |     - |     - |     152 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     1 |    25.8852 ns |  0.3363 ns |  0.2981 ns |  14.52 |    0.23 | 0.0344 |     - |     - |      72 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |     1 |    47.5729 ns |  0.2829 ns |  0.2646 ns |  26.71 |    0.22 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |     1 |    45.7527 ns |  0.2448 ns |  0.2290 ns |  25.69 |    0.25 |      - |     - |     - |         - |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |     1 |    48.2259 ns |  0.1912 ns |  0.1596 ns |  27.05 |    0.20 |      - |     - |     - |         - |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |     1 |     0.8974 ns |  0.0074 ns |  0.0062 ns |   0.50 |    0.01 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     1 |     5.0793 ns |  0.0340 ns |  0.0318 ns |   2.85 |    0.03 |      - |     - |     - |         - |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |     1 |    81.9786 ns |  0.4257 ns |  0.3982 ns |  46.03 |    0.46 | 0.0726 |     - |     - |     152 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     1 |    25.4338 ns |  0.3216 ns |  0.3009 ns |  14.28 |    0.21 | 0.0344 |     - |     - |      72 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |     1 |    38.4507 ns |  0.1799 ns |  0.1595 ns |  21.57 |    0.17 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |     1 |    36.1070 ns |  0.1102 ns |  0.0977 ns |  20.26 |    0.18 |      - |     - |     - |         - |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |     1 |    35.0104 ns |  0.2568 ns |  0.2402 ns |  19.66 |    0.20 |      - |     - |     - |         - |
|                      |               |               |       |               |            |            |        |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |    **10** |    **13.6725 ns** |  **0.1973 ns** |  **0.1846 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |    10 |    29.6707 ns |  0.1517 ns |  0.1419 ns |   2.17 |    0.03 |      - |     - |     - |         - |
|                 Linq |      .NET 4.8 |      .NET 4.8 |    10 |   137.8047 ns |  0.9709 ns |  0.9082 ns |  10.08 |    0.12 | 0.0725 |     - |     - |     152 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |    10 |    88.5220 ns |  0.4817 ns |  0.4270 ns |   6.48 |    0.10 | 0.0650 |     - |     - |     136 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |    10 |    74.5398 ns |  0.3526 ns |  0.3298 ns |   5.45 |    0.09 |      - |     - |     - |         - |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |    10 |    58.4750 ns |  0.3332 ns |  0.3116 ns |   4.28 |    0.05 |      - |     - |     - |         - |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |    10 |   120.1858 ns |  0.3793 ns |  0.3362 ns |   8.80 |    0.13 |      - |     - |     - |         - |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |    10 |    12.6475 ns |  0.0585 ns |  0.0548 ns |   0.93 |    0.01 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |    10 |    26.1464 ns |  0.2297 ns |  0.2149 ns |   1.91 |    0.03 |      - |     - |     - |         - |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |    10 |   153.3899 ns |  0.9442 ns |  0.8832 ns |  11.22 |    0.16 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |    10 |    79.3716 ns |  0.7357 ns |  0.6522 ns |   5.81 |    0.10 | 0.0612 |     - |     - |     128 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |    10 |    74.5901 ns |  0.6273 ns |  0.5238 ns |   5.47 |    0.10 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |    10 |    59.7343 ns |  0.2362 ns |  0.2094 ns |   4.37 |    0.06 |      - |     - |     - |         - |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |    10 |    80.5196 ns |  0.4189 ns |  0.3713 ns |   5.89 |    0.09 |      - |     - |     - |         - |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |    10 |    12.5863 ns |  0.0506 ns |  0.0422 ns |   0.92 |    0.01 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |    10 |    27.8001 ns |  0.1128 ns |  0.1055 ns |   2.03 |    0.03 |      - |     - |     - |         - |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |    10 |   153.2800 ns |  1.6962 ns |  1.5867 ns |  11.21 |    0.13 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |    10 |    74.5171 ns |  0.3704 ns |  0.3465 ns |   5.45 |    0.07 | 0.0612 |     - |     - |     128 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |    10 |    67.0221 ns |  0.3331 ns |  0.3116 ns |   4.90 |    0.07 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |    10 |    51.1667 ns |  0.2205 ns |  0.1954 ns |   3.75 |    0.05 |      - |     - |     - |         - |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |    10 |    68.7508 ns |  0.2947 ns |  0.2461 ns |   5.04 |    0.08 |      - |     - |     - |         - |
|                      |               |               |       |               |            |            |        |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |  **1000** | **1,304.8346 ns** | **15.9829 ns** | **14.9504 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |  1000 | 1,903.4036 ns |  6.5770 ns |  5.4921 ns |   1.46 |    0.02 |      - |     - |     - |         - |
|                 Linq |      .NET 4.8 |      .NET 4.8 |  1000 | 6,595.9197 ns | 31.0566 ns | 27.5308 ns |   5.05 |    0.06 | 0.0687 |     - |     - |     153 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |  1000 | 5,534.2741 ns | 19.7161 ns | 17.4778 ns |   4.24 |    0.05 | 2.0599 |     - |     - |    4325 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |  1000 | 4,076.6416 ns | 23.5654 ns | 19.6781 ns |   3.12 |    0.04 |      - |     - |     - |         - |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |  1000 | 1,695.9219 ns | 20.3295 ns | 18.0216 ns |   1.30 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |  1000 | 6,314.3667 ns | 31.1890 ns | 27.6482 ns |   4.84 |    0.06 |      - |     - |     - |         - |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |  1000 | 1,208.1382 ns |  5.7390 ns |  5.0875 ns |   0.93 |    0.01 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |  1000 | 2,270.6239 ns | 10.7729 ns |  9.5499 ns |   1.74 |    0.02 |      - |     - |     - |         - |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |  1000 | 7,359.3744 ns | 31.8231 ns | 28.2104 ns |   5.64 |    0.07 | 0.0687 |     - |     - |     152 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |  1000 | 3,854.5550 ns | 20.2971 ns | 18.9859 ns |   2.95 |    0.04 | 2.0523 |     - |     - |    4304 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |  1000 | 4,094.2735 ns | 17.5200 ns | 15.5310 ns |   3.14 |    0.04 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |  1000 | 1,505.5120 ns |  8.6339 ns |  7.6537 ns |   1.15 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |  1000 | 4,130.1394 ns | 23.3864 ns | 21.8757 ns |   3.17 |    0.04 |      - |     - |     - |         - |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |  1000 | 1,205.3677 ns |  7.5341 ns |  6.6788 ns |   0.92 |    0.01 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |  1000 | 2,215.6452 ns | 17.3794 ns | 15.4064 ns |   1.70 |    0.02 |      - |     - |     - |         - |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |  1000 | 6,909.1130 ns | 25.4601 ns | 22.5697 ns |   5.29 |    0.07 | 0.0687 |     - |     - |     152 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |  1000 | 4,388.2542 ns | 28.4187 ns | 26.5829 ns |   3.36 |    0.05 | 2.0523 |     - |     - |    4304 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |  1000 | 4,214.9212 ns | 41.1447 ns | 36.4737 ns |   3.23 |    0.03 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |  1000 | 1,520.3153 ns |  7.5127 ns |  6.6598 ns |   1.16 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |  1000 | 4,044.6951 ns | 19.3175 ns | 17.1244 ns |   3.10 |    0.04 |      - |     - |     - |         - |

## ListWhereSelectToArray

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET 4.8      : .NET Framework 4.8 (4.8.4180.0), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT


```
|               Method |           Job |       Runtime | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |-------------- |-------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **0** |    **13.194 ns** |  **0.1073 ns** |  **0.0951 ns** |  **1.00** |    **0.00** | **0.0306** |     **-** |     **-** |      **64 B** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |     0 |    24.182 ns |  0.1576 ns |  0.1397 ns |  1.83 |    0.02 | 0.0306 |     - |     - |      64 B |
|                 Linq |      .NET 4.8 |      .NET 4.8 |     0 |    80.398 ns |  0.5394 ns |  0.4782 ns |  6.09 |    0.05 | 0.0842 |     - |     - |     177 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |     0 |    15.329 ns |  0.0922 ns |  0.0862 ns |  1.16 |    0.01 | 0.0306 |     - |     - |      64 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |    67.410 ns |  0.3018 ns |  0.2675 ns |  5.11 |    0.04 | 0.0535 |     - |     - |     112 B |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |     0 |    69.861 ns |  0.3944 ns |  0.3689 ns |  5.29 |    0.05 | 0.0535 |     - |     - |     112 B |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |     0 |    92.112 ns |  0.6073 ns |  0.5384 ns |  6.98 |    0.07 | 0.0114 |     - |     - |      24 B |
|       Hyperlinq_Pool |      .NET 4.8 |      .NET 4.8 |     0 |           NA |         NA |         NA |     ? |       ? |      - |     - |     - |         - |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |     5.606 ns |  0.0752 ns |  0.0628 ns |  0.43 |    0.00 | 0.0153 |     - |     - |      32 B |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |    10.057 ns |  0.0782 ns |  0.0693 ns |  0.76 |    0.01 | 0.0153 |     - |     - |      32 B |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |    66.514 ns |  0.6669 ns |  0.5912 ns |  5.04 |    0.06 | 0.0726 |     - |     - |     152 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     0 |     8.214 ns |  0.0664 ns |  0.0621 ns |  0.62 |    0.01 | 0.0153 |     - |     - |      32 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |    59.184 ns |  0.3805 ns |  0.3373 ns |  4.49 |    0.04 | 0.0381 |     - |     - |      80 B |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |     0 |    61.166 ns |  0.3900 ns |  0.3457 ns |  4.64 |    0.05 | 0.0381 |     - |     - |      80 B |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |     0 |    72.472 ns |  0.3682 ns |  0.3074 ns |  5.50 |    0.05 | 0.0113 |     - |     - |      24 B |
|       Hyperlinq_Pool | .NET Core 3.1 | .NET Core 3.1 |     0 |           NA |         NA |         NA |     ? |       ? |      - |     - |     - |         - |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |     5.946 ns |  0.0929 ns |  0.0776 ns |  0.45 |    0.01 | 0.0153 |     - |     - |      32 B |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |     9.604 ns |  0.0643 ns |  0.0570 ns |  0.73 |    0.01 | 0.0153 |     - |     - |      32 B |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |    68.421 ns |  0.6347 ns |  0.4955 ns |  5.18 |    0.05 | 0.0726 |     - |     - |     152 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     0 |     8.653 ns |  0.1062 ns |  0.0942 ns |  0.66 |    0.01 | 0.0153 |     - |     - |      32 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |    42.917 ns |  0.3497 ns |  0.3271 ns |  3.25 |    0.03 | 0.0382 |     - |     - |      80 B |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |     0 |    44.754 ns |  0.2649 ns |  0.2212 ns |  3.39 |    0.04 | 0.0382 |     - |     - |      80 B |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |     0 |    50.085 ns |  0.3301 ns |  0.3088 ns |  3.80 |    0.03 | 0.0114 |     - |     - |      24 B |
|       Hyperlinq_Pool | .NET Core 5.0 | .NET Core 5.0 |     0 |           NA |         NA |         NA |     ? |       ? |      - |     - |     - |         - |
|                      |               |               |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **1** |    **31.246 ns** |  **0.2662 ns** |  **0.2223 ns** |  **1.00** |    **0.00** | **0.0535** |     **-** |     **-** |     **112 B** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |     1 |    41.850 ns |  0.2697 ns |  0.2391 ns |  1.34 |    0.01 | 0.0535 |     - |     - |     112 B |
|                 Linq |      .NET 4.8 |      .NET 4.8 |     1 |   107.530 ns |  0.6615 ns |  0.6188 ns |  3.44 |    0.03 | 0.1070 |     - |     - |     225 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |     1 |    36.932 ns |  0.1901 ns |  0.1686 ns |  1.18 |    0.01 | 0.0535 |     - |     - |     112 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |     1 |    86.640 ns |  0.4003 ns |  0.3745 ns |  2.77 |    0.02 | 0.0764 |     - |     - |     160 B |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |     1 |    85.941 ns |  0.3824 ns |  0.3390 ns |  2.75 |    0.02 | 0.0764 |     - |     - |     160 B |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |     1 |   158.040 ns |  0.5836 ns |  0.5173 ns |  5.06 |    0.04 | 0.0153 |     - |     - |      32 B |
|       Hyperlinq_Pool |      .NET 4.8 |      .NET 4.8 |     1 |   280.385 ns |  1.5459 ns |  1.4460 ns |  8.97 |    0.08 | 0.0267 |     - |     - |      56 B |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |     1 |    33.926 ns |  0.2809 ns |  0.2490 ns |  1.09 |    0.01 | 0.0497 |     - |     - |     104 B |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     1 |    38.014 ns |  0.3118 ns |  0.2604 ns |  1.22 |    0.01 | 0.0497 |     - |     - |     104 B |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |     1 |    91.890 ns |  0.7503 ns |  0.7019 ns |  2.94 |    0.03 | 0.0880 |     - |     - |     184 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     1 |    37.496 ns |  0.2123 ns |  0.1986 ns |  1.20 |    0.01 | 0.0497 |     - |     - |     104 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |     1 |    88.201 ns |  0.5598 ns |  0.4674 ns |  2.82 |    0.03 | 0.0726 |     - |     - |     152 B |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |     1 |    88.059 ns |  0.3885 ns |  0.3444 ns |  2.82 |    0.02 | 0.0725 |     - |     - |     152 B |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |     1 |   123.987 ns |  1.2392 ns |  1.0985 ns |  3.97 |    0.03 | 0.0150 |     - |     - |      32 B |
|       Hyperlinq_Pool | .NET Core 3.1 | .NET Core 3.1 |     1 |   229.461 ns |  0.9611 ns |  0.8026 ns |  7.34 |    0.07 | 0.0267 |     - |     - |      56 B |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |     1 |    27.471 ns |  0.2732 ns |  0.2556 ns |  0.88 |    0.01 | 0.0497 |     - |     - |     104 B |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     1 |    34.559 ns |  0.2481 ns |  0.2199 ns |  1.11 |    0.01 | 0.0497 |     - |     - |     104 B |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |     1 |    91.792 ns |  0.6164 ns |  0.5148 ns |  2.94 |    0.02 | 0.0880 |     - |     - |     184 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     1 |    34.500 ns |  0.3949 ns |  0.3500 ns |  1.10 |    0.01 | 0.0497 |     - |     - |     104 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |     1 |    69.303 ns |  0.5877 ns |  0.5210 ns |  2.22 |    0.02 | 0.0725 |     - |     - |     152 B |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |     1 |    68.108 ns |  0.3168 ns |  0.2963 ns |  2.18 |    0.02 | 0.0725 |     - |     - |     152 B |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |     1 |    88.266 ns |  0.5531 ns |  0.5174 ns |  2.83 |    0.02 | 0.0150 |     - |     - |      32 B |
|       Hyperlinq_Pool | .NET Core 5.0 | .NET Core 5.0 |     1 |   198.937 ns |  0.6144 ns |  0.5131 ns |  6.37 |    0.05 | 0.0267 |     - |     - |      56 B |
|                      |               |               |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |    **10** |    **74.627 ns** |  **1.4860 ns** |  **1.3173 ns** |  **1.00** |    **0.00** | **0.0880** |     **-** |     **-** |     **185 B** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |    10 |    91.928 ns |  1.0147 ns |  0.7922 ns |  1.24 |    0.02 | 0.0880 |     - |     - |     185 B |
|                 Linq |      .NET 4.8 |      .NET 4.8 |    10 |   187.599 ns |  0.8932 ns |  0.8355 ns |  2.52 |    0.04 | 0.1414 |     - |     - |     297 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |    10 |    98.655 ns |  0.4619 ns |  0.3857 ns |  1.33 |    0.02 | 0.0880 |     - |     - |     185 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |    10 |   157.692 ns |  1.4501 ns |  1.2109 ns |  2.12 |    0.04 | 0.1109 |     - |     - |     233 B |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |    10 |   129.989 ns |  1.4580 ns |  1.2925 ns |  1.74 |    0.04 | 0.1109 |     - |     - |     233 B |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |    10 |   200.899 ns |  1.2949 ns |  1.1479 ns |  2.69 |    0.05 | 0.0229 |     - |     - |      48 B |
|       Hyperlinq_Pool |      .NET 4.8 |      .NET 4.8 |    10 |   323.380 ns |  2.4717 ns |  2.1911 ns |  4.33 |    0.09 | 0.0267 |     - |     - |      56 B |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |    10 |    69.720 ns |  0.5346 ns |  0.4739 ns |  0.93 |    0.02 | 0.0842 |     - |     - |     176 B |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |    10 |    90.468 ns |  0.5029 ns |  0.4704 ns |  1.21 |    0.02 | 0.0842 |     - |     - |     176 B |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |    10 |   166.760 ns |  1.6017 ns |  1.4198 ns |  2.24 |    0.04 | 0.1414 |     - |     - |     296 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |    10 |    97.819 ns |  0.8190 ns |  0.7260 ns |  1.31 |    0.02 | 0.0842 |     - |     - |     176 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |    10 |   150.214 ns |  1.2989 ns |  1.2150 ns |  2.01 |    0.05 | 0.1070 |     - |     - |     224 B |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |    10 |   127.108 ns |  0.8461 ns |  0.7065 ns |  1.71 |    0.03 | 0.1070 |     - |     - |     224 B |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |    10 |   151.500 ns |  0.9674 ns |  0.8078 ns |  2.04 |    0.03 | 0.0229 |     - |     - |      48 B |
|       Hyperlinq_Pool | .NET Core 3.1 | .NET Core 3.1 |    10 |   268.001 ns |  1.4268 ns |  1.3346 ns |  3.59 |    0.07 | 0.0267 |     - |     - |      56 B |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |    10 |    60.405 ns |  0.6386 ns |  0.5973 ns |  0.81 |    0.02 | 0.0842 |     - |     - |     176 B |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |    10 |    79.585 ns |  0.8126 ns |  0.7204 ns |  1.07 |    0.03 | 0.0842 |     - |     - |     176 B |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |    10 |   154.869 ns |  0.8276 ns |  0.6461 ns |  2.08 |    0.03 | 0.1414 |     - |     - |     296 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |    10 |    78.439 ns |  0.6817 ns |  0.6377 ns |  1.05 |    0.02 | 0.0842 |     - |     - |     176 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |    10 |   125.990 ns |  1.1158 ns |  0.9891 ns |  1.69 |    0.03 | 0.1066 |     - |     - |     224 B |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |    10 |    99.613 ns |  0.9479 ns |  0.8403 ns |  1.34 |    0.03 | 0.1069 |     - |     - |     224 B |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |    10 |   116.047 ns |  0.9935 ns |  0.9293 ns |  1.55 |    0.03 | 0.0224 |     - |     - |      48 B |
|       Hyperlinq_Pool | .NET Core 5.0 | .NET Core 5.0 |    10 |   225.710 ns |  0.7448 ns |  0.5815 ns |  3.04 |    0.05 | 0.0267 |     - |     - |      56 B |
|                      |               |               |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |  **1000** | **2,709.557 ns** | **18.6113 ns** | **15.5413 ns** |  **1.00** |    **0.00** | **3.0289** |     **-** |     **-** |    **6355 B** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |  1000 | 3,541.245 ns | 18.1031 ns | 16.0480 ns |  1.31 |    0.01 | 3.0289 |     - |     - |    6355 B |
|                 Linq |      .NET 4.8 |      .NET 4.8 |  1000 | 7,578.429 ns | 35.4139 ns | 29.5722 ns |  2.80 |    0.02 | 3.0670 |     - |     - |    6469 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |  1000 | 5,335.018 ns | 34.5294 ns | 30.6094 ns |  1.97 |    0.02 | 3.0289 |     - |     - |    6355 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |  1000 | 5,781.603 ns | 51.1604 ns | 42.7213 ns |  2.13 |    0.02 | 3.0441 |     - |     - |    6404 B |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |  1000 | 3,227.721 ns | 12.9644 ns | 11.4926 ns |  1.19 |    0.01 | 3.0479 |     - |     - |    6404 B |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |  1000 | 5,455.327 ns | 27.8173 ns | 24.6593 ns |  2.01 |    0.02 | 0.9613 |     - |     - |    2030 B |
|       Hyperlinq_Pool |      .NET 4.8 |      .NET 4.8 |  1000 | 5,544.203 ns | 33.3142 ns | 31.1621 ns |  2.04 |    0.02 | 0.0229 |     - |     - |      56 B |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |  1000 | 2,013.799 ns | 12.7104 ns | 11.8893 ns |  0.74 |    0.01 | 3.0251 |     - |     - |    6328 B |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |  1000 | 3,665.544 ns | 27.4416 ns | 21.4246 ns |  1.35 |    0.01 | 3.0251 |     - |     - |    6328 B |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |  1000 | 4,307.034 ns | 29.8032 ns | 26.4198 ns |  1.59 |    0.02 | 2.1820 |     - |     - |    4576 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |  1000 | 4,972.202 ns | 15.5758 ns | 13.8075 ns |  1.84 |    0.01 | 3.0212 |     - |     - |    6328 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |  1000 | 5,321.957 ns | 35.5301 ns | 29.6692 ns |  1.96 |    0.02 | 3.0441 |     - |     - |    6376 B |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |  1000 | 2,548.576 ns | 26.8607 ns | 25.1255 ns |  0.94 |    0.01 | 3.0479 |     - |     - |    6376 B |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |  1000 | 4,338.329 ns | 18.4009 ns | 15.3656 ns |  1.60 |    0.01 | 0.9613 |     - |     - |    2024 B |
|       Hyperlinq_Pool | .NET Core 3.1 | .NET Core 3.1 |  1000 | 3,837.416 ns | 31.1978 ns | 27.6560 ns |  1.42 |    0.01 | 0.0229 |     - |     - |      56 B |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |  1000 | 1,965.626 ns | 25.9663 ns | 21.6830 ns |  0.73 |    0.01 | 3.0251 |     - |     - |    6328 B |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |  1000 | 3,617.073 ns | 19.3717 ns | 18.1203 ns |  1.34 |    0.01 | 3.0251 |     - |     - |    6328 B |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |  1000 | 3,921.178 ns | 21.1617 ns | 17.6710 ns |  1.45 |    0.01 | 2.1820 |     - |     - |    4576 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |  1000 | 3,672.812 ns | 22.5422 ns | 19.9831 ns |  1.36 |    0.01 | 3.0251 |     - |     - |    6328 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |  1000 | 5,324.017 ns | 27.1446 ns | 24.0630 ns |  1.96 |    0.02 | 3.0441 |     - |     - |    6376 B |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |  1000 | 2,458.496 ns | 16.8880 ns | 14.1022 ns |  0.91 |    0.01 | 3.0479 |     - |     - |    6376 B |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |  1000 | 3,955.323 ns | 13.8078 ns | 11.5302 ns |  1.46 |    0.01 | 0.9613 |     - |     - |    2024 B |
|       Hyperlinq_Pool | .NET Core 5.0 | .NET Core 5.0 |  1000 | 4,091.283 ns | 16.9221 ns | 15.0010 ns |  1.51 |    0.01 | 0.0229 |     - |     - |      56 B |

Benchmarks with issues:
  ListWhereSelectToArray.Hyperlinq_Pool: .NET 4.8(Runtime=.NET 4.8) [Count=0]
  ListWhereSelectToArray.Hyperlinq_Pool: .NET Core 3.1(Runtime=.NET Core 3.1) [Count=0]
  ListWhereSelectToArray.Hyperlinq_Pool: .NET Core 5.0(Runtime=.NET Core 5.0) [Count=0]

## ListWhereSelectToList

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET 4.8      : .NET Framework 4.8 (4.8.4180.0), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT


```
|               Method |           Job |       Runtime | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |-------------- |-------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **0** |     **4.917 ns** |  **0.0588 ns** |  **0.0521 ns** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |     0 |    13.607 ns |  0.1370 ns |  0.1214 ns |  2.77 |    0.04 | 0.0191 |     - |     - |      40 B |
|                 Linq |      .NET 4.8 |      .NET 4.8 |     0 |    88.855 ns |  0.5577 ns |  0.5217 ns | 18.08 |    0.21 | 0.0918 |     - |     - |     193 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |     0 |    20.120 ns |  0.1212 ns |  0.1074 ns |  4.09 |    0.05 | 0.0382 |     - |     - |      80 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |    58.712 ns |  0.5606 ns |  0.4970 ns | 11.94 |    0.18 | 0.0421 |     - |     - |      88 B |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |     0 |    60.757 ns |  0.5259 ns |  0.4919 ns | 12.35 |    0.11 | 0.0421 |     - |     - |      88 B |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |     0 |   116.686 ns |  1.1065 ns |  0.9809 ns | 23.73 |    0.33 | 0.0534 |     - |     - |     112 B |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |     4.796 ns |  0.0368 ns |  0.0326 ns |  0.98 |    0.01 | 0.0153 |     - |     - |      32 B |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |     7.409 ns |  0.0706 ns |  0.0589 ns |  1.51 |    0.02 | 0.0153 |     - |     - |      32 B |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |    58.265 ns |  0.6213 ns |  0.5508 ns | 11.85 |    0.21 | 0.0880 |     - |     - |     184 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     0 |    17.386 ns |  0.1326 ns |  0.1176 ns |  3.54 |    0.04 | 0.0306 |     - |     - |      64 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |    58.485 ns |  0.5247 ns |  0.4652 ns | 11.90 |    0.13 | 0.0381 |     - |     - |      80 B |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |     0 |    60.979 ns |  0.3455 ns |  0.3062 ns | 12.40 |    0.13 | 0.0381 |     - |     - |      80 B |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |     0 |    97.382 ns |  1.1196 ns |  0.9925 ns | 19.81 |    0.28 | 0.0496 |     - |     - |     104 B |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |     4.888 ns |  0.0621 ns |  0.0551 ns |  0.99 |    0.01 | 0.0153 |     - |     - |      32 B |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |     7.824 ns |  0.0823 ns |  0.0730 ns |  1.59 |    0.03 | 0.0153 |     - |     - |      32 B |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |    66.595 ns |  0.5503 ns |  0.4595 ns | 13.56 |    0.13 | 0.0880 |     - |     - |     184 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     0 |    17.563 ns |  0.2656 ns |  0.2485 ns |  3.58 |    0.07 | 0.0306 |     - |     - |      64 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |    42.413 ns |  0.3315 ns |  0.2938 ns |  8.63 |    0.12 | 0.0381 |     - |     - |      80 B |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |     0 |    43.949 ns |  0.3226 ns |  0.3018 ns |  8.94 |    0.12 | 0.0381 |     - |     - |      80 B |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |     0 |    73.840 ns |  1.0125 ns |  0.8455 ns | 15.03 |    0.20 | 0.0495 |     - |     - |     104 B |
|                      |               |               |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **1** |    **17.619 ns** |  **0.0960 ns** |  **0.0851 ns** |  **1.00** |    **0.00** | **0.0382** |     **-** |     **-** |      **80 B** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |     1 |    28.325 ns |  0.2236 ns |  0.2092 ns |  1.61 |    0.01 | 0.0382 |     - |     - |      80 B |
|                 Linq |      .NET 4.8 |      .NET 4.8 |     1 |   118.494 ns |  0.8188 ns |  0.7259 ns |  6.73 |    0.06 | 0.1109 |     - |     - |     233 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |     1 |    49.452 ns |  0.3635 ns |  0.3400 ns |  2.81 |    0.02 | 0.0727 |     - |     - |     152 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |     1 |    74.030 ns |  0.6173 ns |  0.5774 ns |  4.20 |    0.03 | 0.0612 |     - |     - |     128 B |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |     1 |    73.985 ns |  0.5417 ns |  0.4802 ns |  4.20 |    0.04 | 0.0612 |     - |     - |     128 B |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |     1 |   190.120 ns |  1.7011 ns |  1.5080 ns | 10.79 |    0.09 | 0.0687 |     - |     - |     144 B |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |     1 |    18.046 ns |  0.0901 ns |  0.0753 ns |  1.02 |    0.01 | 0.0344 |     - |     - |      72 B |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     1 |    22.947 ns |  0.2146 ns |  0.1903 ns |  1.30 |    0.01 | 0.0344 |     - |     - |      72 B |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |     1 |    75.605 ns |  0.3983 ns |  0.3326 ns |  4.29 |    0.03 | 0.1069 |     - |     - |     224 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     1 |    48.194 ns |  0.4346 ns |  0.3629 ns |  2.74 |    0.02 | 0.0650 |     - |     - |     136 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |     1 |    75.104 ns |  0.5161 ns |  0.4310 ns |  4.26 |    0.03 | 0.0572 |     - |     - |     120 B |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |     1 |    74.494 ns |  0.4903 ns |  0.4347 ns |  4.23 |    0.03 | 0.0573 |     - |     - |     120 B |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |     1 |   155.382 ns |  1.2500 ns |  1.1693 ns |  8.82 |    0.07 | 0.0648 |     - |     - |     136 B |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |     1 |    18.944 ns |  0.1740 ns |  0.1542 ns |  1.08 |    0.01 | 0.0344 |     - |     - |      72 B |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     1 |    22.283 ns |  0.3899 ns |  0.3648 ns |  1.27 |    0.02 | 0.0344 |     - |     - |      72 B |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |     1 |    80.389 ns |  0.8966 ns |  0.8387 ns |  4.56 |    0.06 | 0.1070 |     - |     - |     224 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     1 |    46.805 ns |  0.3665 ns |  0.3249 ns |  2.66 |    0.03 | 0.0649 |     - |     - |     136 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |     1 |    58.944 ns |  0.4705 ns |  0.4171 ns |  3.35 |    0.02 | 0.0573 |     - |     - |     120 B |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |     1 |    57.505 ns |  0.3560 ns |  0.3156 ns |  3.26 |    0.03 | 0.0571 |     - |     - |     120 B |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |     1 |   124.356 ns |  1.8372 ns |  1.5341 ns |  7.06 |    0.08 | 0.0648 |     - |     - |     136 B |
|                      |               |               |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |    **10** |    **61.887 ns** |  **0.6587 ns** |  **0.6161 ns** |  **1.00** |    **0.00** | **0.0650** |     **-** |     **-** |     **136 B** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |    10 |    74.799 ns |  0.5486 ns |  0.4863 ns |  1.21 |    0.01 | 0.0650 |     - |     - |     136 B |
|                 Linq |      .NET 4.8 |      .NET 4.8 |    10 |   214.003 ns |  1.5547 ns |  1.3782 ns |  3.46 |    0.04 | 0.1376 |     - |     - |     289 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |    10 |   112.219 ns |  1.2071 ns |  1.0701 ns |  1.81 |    0.03 | 0.1070 |     - |     - |     225 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |    10 |   145.297 ns |  1.3531 ns |  1.2657 ns |  2.35 |    0.04 | 0.0880 |     - |     - |     185 B |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |    10 |   114.247 ns |  1.0926 ns |  0.9124 ns |  1.85 |    0.02 | 0.0880 |     - |     - |     185 B |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |    10 |   229.387 ns |  1.0307 ns |  0.9137 ns |  3.71 |    0.04 | 0.0763 |     - |     - |     160 B |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |    10 |    55.055 ns |  0.5100 ns |  0.3981 ns |  0.89 |    0.01 | 0.0610 |     - |     - |     128 B |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |    10 |    69.568 ns |  0.8043 ns |  0.7523 ns |  1.12 |    0.02 | 0.0612 |     - |     - |     128 B |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |    10 |   136.750 ns |  1.4635 ns |  1.3689 ns |  2.21 |    0.03 | 0.1338 |     - |     - |     280 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |    10 |   105.609 ns |  0.6742 ns |  0.5630 ns |  1.71 |    0.02 | 0.0993 |     - |     - |     208 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |    10 |   133.301 ns |  1.3123 ns |  1.1633 ns |  2.16 |    0.03 | 0.0842 |     - |     - |     176 B |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |    10 |   109.797 ns |  0.7232 ns |  0.6411 ns |  1.78 |    0.02 | 0.0840 |     - |     - |     176 B |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |    10 |   188.946 ns |  0.8087 ns |  0.7169 ns |  3.05 |    0.03 | 0.0725 |     - |     - |     152 B |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |    10 |    45.432 ns |  0.3838 ns |  0.3205 ns |  0.73 |    0.01 | 0.0612 |     - |     - |     128 B |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |    10 |    63.937 ns |  0.5260 ns |  0.4392 ns |  1.03 |    0.01 | 0.0610 |     - |     - |     128 B |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |    10 |   128.331 ns |  0.9945 ns |  0.9303 ns |  2.07 |    0.03 | 0.1338 |     - |     - |     280 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |    10 |    91.066 ns |  0.5217 ns |  0.4880 ns |  1.47 |    0.02 | 0.0994 |     - |     - |     208 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |    10 |   112.328 ns |  0.7820 ns |  0.6932 ns |  1.82 |    0.02 | 0.0842 |     - |     - |     176 B |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |    10 |    88.367 ns |  0.5644 ns |  0.5003 ns |  1.43 |    0.02 | 0.0839 |     - |     - |     176 B |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |    10 |   155.694 ns |  1.8107 ns |  1.6052 ns |  2.52 |    0.03 | 0.0725 |     - |     - |     152 B |
|                      |               |               |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |  **1000** | **2,660.164 ns** | **14.8296 ns** | **13.1461 ns** |  **1.00** |    **0.00** | **2.0599** |     **-** |     **-** |    **4325 B** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |  1000 | 3,391.007 ns | 17.3465 ns | 16.2260 ns |  1.27 |    0.01 | 2.0599 |     - |     - |    4325 B |
|                 Linq |      .NET 4.8 |      .NET 4.8 |  1000 | 8,236.112 ns | 53.8856 ns | 47.7682 ns |  3.10 |    0.02 | 2.1210 |     - |     - |    4478 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |  1000 | 5,354.285 ns | 32.1919 ns | 30.1123 ns |  2.01 |    0.01 | 3.0441 |     - |     - |    6395 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |  1000 | 6,034.439 ns | 31.3181 ns | 27.7627 ns |  2.27 |    0.02 | 2.0828 |     - |     - |    4373 B |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |  1000 | 3,055.953 ns | 14.5301 ns | 12.1333 ns |  1.15 |    0.01 | 2.0828 |     - |     - |    4373 B |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |  1000 | 5,023.655 ns | 35.4699 ns | 33.1786 ns |  1.89 |    0.01 | 1.0147 |     - |     - |    2144 B |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |  1000 | 1,876.289 ns | 10.6309 ns |  9.4240 ns |  0.71 |    0.00 | 2.0561 |     - |     - |    4304 B |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |  1000 | 3,141.849 ns | 26.1009 ns | 23.1378 ns |  1.18 |    0.01 | 2.0561 |     - |     - |    4304 B |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |  1000 | 4,256.735 ns | 29.9133 ns | 27.9809 ns |  1.60 |    0.01 | 2.1286 |     - |     - |    4456 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |  1000 | 4,376.107 ns | 21.9785 ns | 20.5587 ns |  1.64 |    0.01 | 3.0365 |     - |     - |    6360 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |  1000 | 5,125.405 ns | 39.8623 ns | 37.2872 ns |  1.93 |    0.02 | 2.0752 |     - |     - |    4352 B |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |  1000 | 2,380.375 ns | 19.2722 ns | 18.0272 ns |  0.89 |    0.01 | 2.0790 |     - |     - |    4352 B |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |  1000 | 4,576.436 ns | 22.5061 ns | 19.9510 ns |  1.72 |    0.01 | 1.0147 |     - |     - |    2128 B |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |  1000 | 1,818.952 ns |  9.3668 ns |  8.3034 ns |  0.68 |    0.00 | 2.0561 |     - |     - |    4304 B |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |  1000 | 3,078.355 ns | 25.1517 ns | 22.2964 ns |  1.16 |    0.01 | 2.0561 |     - |     - |    4304 B |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |  1000 | 4,057.496 ns | 18.3337 ns | 17.1493 ns |  1.53 |    0.01 | 2.1286 |     - |     - |    4456 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |  1000 | 3,747.190 ns | 19.2012 ns | 17.9608 ns |  1.41 |    0.01 | 3.0365 |     - |     - |    6360 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |  1000 | 5,209.907 ns | 42.3640 ns | 37.5546 ns |  1.96 |    0.02 | 2.0752 |     - |     - |    4352 B |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |  1000 | 2,329.270 ns | 22.2642 ns | 19.7366 ns |  0.88 |    0.01 | 2.0790 |     - |     - |    4352 B |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |  1000 | 4,031.840 ns | 40.1425 ns | 37.5494 ns |  1.51 |    0.02 | 1.0147 |     - |     - |    2128 B |

## Range

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET 4.8      : .NET Framework 4.8 (4.8.4180.0), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT


```
|               Method |           Job |       Runtime | Start | Count |          Mean |      Error |     StdDev |        Median |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |-------------- |-------------- |------ |------ |--------------:|-----------:|-----------:|--------------:|-------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **0** |     **0** |     **0.2809 ns** |  **0.0099 ns** |  **0.0093 ns** |     **0.2800 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |     0 |     0 |    16.8401 ns |  0.1388 ns |  0.1298 ns |    16.8194 ns |  60.00 |    1.89 | 0.0268 |     - |     - |      56 B |
|                 Linq |      .NET 4.8 |      .NET 4.8 |     0 |     0 |    17.7370 ns |  0.1387 ns |  0.1297 ns |    17.7764 ns |  63.20 |    2.20 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |     0 |     0 |     5.1176 ns |  0.0309 ns |  0.0274 ns |     5.1109 ns |  18.23 |    0.62 | 0.0115 |     - |     - |      24 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |     0 |     6.4084 ns |  0.0339 ns |  0.0300 ns |     6.3986 ns |  22.83 |    0.79 |      - |     - |     - |         - |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |     0 |     0 |     6.4015 ns |  0.0246 ns |  0.0230 ns |     6.4048 ns |  22.81 |    0.75 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |      .NET 4.8 |      .NET 4.8 |     0 |     0 |    15.8054 ns |  0.1051 ns |  0.0983 ns |    15.8276 ns |  56.32 |    2.06 |      - |     - |     - |         - |
|        Hyperlinq_For |      .NET 4.8 |      .NET 4.8 |     0 |     0 |     3.2524 ns |  0.0382 ns |  0.0357 ns |     3.2480 ns |  11.59 |    0.40 |      - |     - |     - |         - |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |     0 |     0.2972 ns |  0.0113 ns |  0.0101 ns |     0.2958 ns |   1.06 |    0.05 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |     0 |    24.0511 ns |  0.5069 ns |  0.8469 ns |    23.6039 ns |  88.19 |    4.52 | 0.0268 |     - |     - |      56 B |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |     0 |     7.5156 ns |  0.0335 ns |  0.0313 ns |     7.5089 ns |  26.78 |    0.88 |      - |     - |     - |         - |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     0 |     0 |     5.4111 ns |  0.0428 ns |  0.0380 ns |     5.4123 ns |  19.28 |    0.73 | 0.0115 |     - |     - |      24 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |     0 |     6.3719 ns |  0.0415 ns |  0.0388 ns |     6.3756 ns |  22.70 |    0.75 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |     0 |     0 |     6.3893 ns |  0.0368 ns |  0.0344 ns |     6.3886 ns |  22.77 |    0.77 |      - |     - |     - |         - |
|    Hyperlinq_Foreach | .NET Core 3.1 | .NET Core 3.1 |     0 |     0 |     9.8724 ns |  0.0513 ns |  0.0454 ns |     9.8871 ns |  35.17 |    1.23 |      - |     - |     - |         - |
|        Hyperlinq_For | .NET Core 3.1 | .NET Core 3.1 |     0 |     0 |     3.2408 ns |  0.0244 ns |  0.0216 ns |     3.2390 ns |  11.54 |    0.38 |      - |     - |     - |         - |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |     0 |     0.2491 ns |  0.0091 ns |  0.0085 ns |     0.2489 ns |   0.89 |    0.03 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |     0 |    23.2245 ns |  0.1534 ns |  0.1360 ns |    23.2843 ns |  82.74 |    2.84 | 0.0268 |     - |     - |      56 B |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |     0 |     7.1170 ns |  0.0663 ns |  0.0588 ns |     7.1094 ns |  25.36 |    0.97 |      - |     - |     - |         - |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     0 |     0 |     5.1817 ns |  0.0695 ns |  0.0616 ns |     5.1724 ns |  18.46 |    0.62 | 0.0115 |     - |     - |      24 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |     0 |     6.1841 ns |  0.0274 ns |  0.0256 ns |     6.1795 ns |  22.04 |    0.75 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |     0 |     0 |     6.1922 ns |  0.0435 ns |  0.0386 ns |     6.1945 ns |  22.06 |    0.80 |      - |     - |     - |         - |
|    Hyperlinq_Foreach | .NET Core 5.0 | .NET Core 5.0 |     0 |     0 |     9.3698 ns |  0.0582 ns |  0.0516 ns |     9.3677 ns |  33.38 |    1.09 |      - |     - |     - |         - |
|        Hyperlinq_For | .NET Core 5.0 | .NET Core 5.0 |     0 |     0 |     3.1895 ns |  0.0471 ns |  0.0441 ns |     3.1940 ns |  11.36 |    0.40 |      - |     - |     - |         - |
|                      |               |               |       |       |               |            |            |               |        |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **0** |     **1** |     **0.0765 ns** |  **0.0095 ns** |  **0.0074 ns** |     **0.0777 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |     0 |     1 |    20.9390 ns |  0.1290 ns |  0.1077 ns |    20.9195 ns | 276.20 |   27.43 | 0.0268 |     - |     - |      56 B |
|                 Linq |      .NET 4.8 |      .NET 4.8 |     0 |     1 |    21.4832 ns |  0.0975 ns |  0.0865 ns |    21.5067 ns | 283.22 |   28.66 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |     0 |     1 |     4.9729 ns |  0.0513 ns |  0.0455 ns |     4.9775 ns |  65.57 |    6.81 | 0.0153 |     - |     - |      32 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |     1 |     6.7443 ns |  0.0365 ns |  0.0342 ns |     6.7372 ns |  88.91 |    9.06 |      - |     - |     - |         - |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |     0 |     1 |     6.7416 ns |  0.0342 ns |  0.0319 ns |     6.7372 ns |  88.92 |    8.74 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |      .NET 4.8 |      .NET 4.8 |     0 |     1 |    17.0966 ns |  0.0748 ns |  0.0663 ns |    17.1008 ns | 225.50 |   21.91 |      - |     - |     - |         - |
|        Hyperlinq_For |      .NET 4.8 |      .NET 4.8 |     0 |     1 |     3.8875 ns |  0.0271 ns |  0.0253 ns |     3.8866 ns |  51.25 |    5.11 |      - |     - |     - |         - |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |     1 |     0.0512 ns |  0.0079 ns |  0.0070 ns |     0.0511 ns |   0.69 |    0.12 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |     1 |    27.2274 ns |  0.1554 ns |  0.1378 ns |    27.2529 ns | 359.16 |   34.99 | 0.0268 |     - |     - |      56 B |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |     1 |    26.7628 ns |  0.4440 ns |  0.4153 ns |    26.5545 ns | 354.43 |   37.02 | 0.0191 |     - |     - |      40 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     0 |     1 |     5.3378 ns |  0.0864 ns |  0.0808 ns |     5.3334 ns |  70.53 |    7.26 | 0.0153 |     - |     - |      32 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |     1 |     6.6816 ns |  0.0476 ns |  0.0446 ns |     6.6663 ns |  88.26 |    8.68 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |     0 |     1 |     6.6736 ns |  0.0394 ns |  0.0349 ns |     6.6629 ns |  87.98 |    8.66 |      - |     - |     - |         - |
|    Hyperlinq_Foreach | .NET Core 3.1 | .NET Core 3.1 |     0 |     1 |    11.2010 ns |  0.0502 ns |  0.0445 ns |    11.2154 ns | 147.71 |   14.76 |      - |     - |     - |         - |
|        Hyperlinq_For | .NET Core 3.1 | .NET Core 3.1 |     0 |     1 |     3.8413 ns |  0.0353 ns |  0.0313 ns |     3.8298 ns |  50.62 |    4.99 |      - |     - |     - |         - |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |     1 |     0.2082 ns |  0.0067 ns |  0.0059 ns |     0.2078 ns |   2.75 |    0.29 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |     1 |    27.1974 ns |  0.1387 ns |  0.1158 ns |    27.1758 ns | 358.61 |   35.38 | 0.0268 |     - |     - |      56 B |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |     1 |    26.1142 ns |  0.1450 ns |  0.1286 ns |    26.1377 ns | 344.35 |   34.17 | 0.0191 |     - |     - |      40 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     0 |     1 |     5.2257 ns |  0.0701 ns |  0.0622 ns |     5.2292 ns |  68.87 |    6.77 | 0.0153 |     - |     - |      32 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |     1 |     6.4639 ns |  0.0239 ns |  0.0212 ns |     6.4588 ns |  85.25 |    8.36 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |     0 |     1 |     6.5416 ns |  0.0439 ns |  0.0411 ns |     6.5432 ns |  86.26 |    8.58 |      - |     - |     - |         - |
|    Hyperlinq_Foreach | .NET Core 5.0 | .NET Core 5.0 |     0 |     1 |    10.6193 ns |  0.0650 ns |  0.0577 ns |    10.6131 ns | 140.21 |   14.06 |      - |     - |     - |         - |
|        Hyperlinq_For | .NET Core 5.0 | .NET Core 5.0 |     0 |     1 |     3.8532 ns |  0.0630 ns |  0.0526 ns |     3.8638 ns |  50.74 |    4.99 |      - |     - |     - |         - |
|                      |               |               |       |       |               |            |            |               |        |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **0** |    **10** |     **3.4090 ns** |  **0.0314 ns** |  **0.0262 ns** |     **3.4011 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |     0 |    10 |    62.2344 ns |  0.5940 ns |  0.5265 ns |    62.0326 ns |  18.27 |    0.19 | 0.0267 |     - |     - |      56 B |
|                 Linq |      .NET 4.8 |      .NET 4.8 |     0 |    10 |    68.8350 ns |  0.4222 ns |  0.3742 ns |    68.7990 ns |  20.19 |    0.21 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |     0 |    10 |    15.6695 ns |  0.0936 ns |  0.0830 ns |    15.6322 ns |   4.60 |    0.04 | 0.0306 |     - |     - |      64 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |    10 |     9.5291 ns |  0.0356 ns |  0.0333 ns |     9.5263 ns |   2.80 |    0.02 |      - |     - |     - |         - |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |     0 |    10 |     9.5220 ns |  0.0406 ns |  0.0360 ns |     9.5236 ns |   2.79 |    0.02 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |      .NET 4.8 |      .NET 4.8 |     0 |    10 |    30.6082 ns |  0.1633 ns |  0.1363 ns |    30.6199 ns |   8.98 |    0.09 |      - |     - |     - |         - |
|        Hyperlinq_For |      .NET 4.8 |      .NET 4.8 |     0 |    10 |     9.1521 ns |  0.0354 ns |  0.0314 ns |     9.1519 ns |   2.68 |    0.02 |      - |     - |     - |         - |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |    10 |     3.0350 ns |  0.0345 ns |  0.0306 ns |     3.0288 ns |   0.89 |    0.01 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |    10 |    66.0929 ns |  0.7861 ns |  0.6969 ns |    65.8571 ns |  19.41 |    0.25 | 0.0267 |     - |     - |      56 B |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |    10 |    63.2139 ns |  0.4634 ns |  0.4335 ns |    63.3179 ns |  18.52 |    0.18 | 0.0191 |     - |     - |      40 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     0 |    10 |    13.4006 ns |  0.1380 ns |  0.1291 ns |    13.4378 ns |   3.93 |    0.05 | 0.0306 |     - |     - |      64 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |    10 |     9.4486 ns |  0.0297 ns |  0.0278 ns |     9.4551 ns |   2.77 |    0.02 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |     0 |    10 |     9.4334 ns |  0.0404 ns |  0.0358 ns |     9.4380 ns |   2.77 |    0.02 |      - |     - |     - |         - |
|    Hyperlinq_Foreach | .NET Core 3.1 | .NET Core 3.1 |     0 |    10 |    24.9305 ns |  0.0490 ns |  0.0434 ns |    24.9468 ns |   7.31 |    0.05 |      - |     - |     - |         - |
|        Hyperlinq_For | .NET Core 3.1 | .NET Core 3.1 |     0 |    10 |     8.6431 ns |  0.0485 ns |  0.0379 ns |     8.6576 ns |   2.53 |    0.02 |      - |     - |     - |         - |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |    10 |     2.9856 ns |  0.0213 ns |  0.0200 ns |     2.9842 ns |   0.88 |    0.01 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |    10 |    69.3887 ns |  0.3997 ns |  0.3543 ns |    69.3485 ns |  20.36 |    0.21 | 0.0267 |     - |     - |      56 B |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |    10 |    60.9872 ns |  0.4674 ns |  0.4143 ns |    60.9637 ns |  17.89 |    0.11 | 0.0191 |     - |     - |      40 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     0 |    10 |    13.4558 ns |  0.1462 ns |  0.1221 ns |    13.4684 ns |   3.95 |    0.05 | 0.0306 |     - |     - |      64 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |    10 |     9.2201 ns |  0.0492 ns |  0.0460 ns |     9.2150 ns |   2.70 |    0.03 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |     0 |    10 |     9.1867 ns |  0.0430 ns |  0.0381 ns |     9.1894 ns |   2.70 |    0.02 |      - |     - |     - |         - |
|    Hyperlinq_Foreach | .NET Core 5.0 | .NET Core 5.0 |     0 |    10 |    24.6290 ns |  0.1058 ns |  0.0989 ns |    24.6420 ns |   7.22 |    0.06 |      - |     - |     - |         - |
|        Hyperlinq_For | .NET Core 5.0 | .NET Core 5.0 |     0 |    10 |     8.5999 ns |  0.0789 ns |  0.0699 ns |     8.6155 ns |   2.52 |    0.02 |      - |     - |     - |         - |
|                      |               |               |       |       |               |            |            |               |        |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **0** |  **1000** |   **282.0910 ns** |  **2.6956 ns** |  **2.2510 ns** |   **281.5525 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |     0 |  1000 | 4,600.2899 ns | 20.9510 ns | 18.5725 ns | 4,596.2486 ns |  16.31 |    0.16 | 0.0229 |     - |     - |      56 B |
|                 Linq |      .NET 4.8 |      .NET 4.8 |     0 |  1000 | 5,163.8535 ns | 32.4785 ns | 27.1210 ns | 5,156.7604 ns |  18.31 |    0.17 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |     0 |  1000 | 1,157.6415 ns |  6.7378 ns |  5.9729 ns | 1,159.4217 ns |   4.10 |    0.05 | 1.9226 |     - |     - |    4041 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |  1000 |   289.0951 ns |  2.2018 ns |  1.7190 ns |   289.5482 ns |   1.02 |    0.01 |      - |     - |     - |         - |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |     0 |  1000 |   288.6639 ns |  2.4274 ns |  2.0270 ns |   289.0005 ns |   1.02 |    0.01 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |      .NET 4.8 |      .NET 4.8 |     0 |  1000 | 1,543.5624 ns |  5.0413 ns |  4.4690 ns | 1,543.4349 ns |   5.47 |    0.04 |      - |     - |     - |         - |
|        Hyperlinq_For |      .NET 4.8 |      .NET 4.8 |     0 |  1000 |   556.6503 ns |  3.4387 ns |  2.8714 ns |   556.8345 ns |   1.97 |    0.02 |      - |     - |     - |         - |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |  1000 |   281.6370 ns |  2.6688 ns |  2.4964 ns |   281.5504 ns |   1.00 |    0.01 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |  1000 | 4,610.2385 ns | 25.4606 ns | 22.5702 ns | 4,605.6240 ns |  16.33 |    0.12 | 0.0229 |     - |     - |      56 B |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |  1000 | 4,058.1845 ns | 20.7730 ns | 17.3464 ns | 4,052.5642 ns |  14.39 |    0.12 | 0.0153 |     - |     - |      40 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     0 |  1000 | 1,183.6414 ns |  9.6232 ns |  9.0016 ns | 1,182.0846 ns |   4.19 |    0.04 | 1.9226 |     - |     - |    4024 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |  1000 |   288.0214 ns |  1.9930 ns |  1.7667 ns |   287.8121 ns |   1.02 |    0.01 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |     0 |  1000 |   288.7536 ns |  1.7479 ns |  1.5495 ns |   288.8379 ns |   1.02 |    0.01 |      - |     - |     - |         - |
|    Hyperlinq_Foreach | .NET Core 3.1 | .NET Core 3.1 |     0 |  1000 | 1,541.3416 ns |  5.2792 ns |  4.9382 ns | 1,540.5383 ns |   5.46 |    0.05 |      - |     - |     - |         - |
|        Hyperlinq_For | .NET Core 3.1 | .NET Core 3.1 |     0 |  1000 |   558.7069 ns |  4.4716 ns |  3.7340 ns |   559.3382 ns |   1.98 |    0.02 |      - |     - |     - |         - |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |  1000 |   282.1061 ns |  1.8712 ns |  1.6588 ns |   282.1514 ns |   1.00 |    0.01 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |  1000 | 4,360.6332 ns | 18.7589 ns | 16.6293 ns | 4,357.3681 ns |  15.46 |    0.14 | 0.0229 |     - |     - |      56 B |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |  1000 | 4,076.2171 ns | 23.3036 ns | 20.6580 ns | 4,078.7716 ns |  14.45 |    0.14 | 0.0153 |     - |     - |      40 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     0 |  1000 | 1,175.2433 ns |  4.4237 ns |  3.6940 ns | 1,175.6218 ns |   4.17 |    0.03 | 1.9226 |     - |     - |    4024 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |  1000 |   288.0216 ns |  2.7229 ns |  2.4138 ns |   288.8119 ns |   1.02 |    0.01 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |     0 |  1000 |   286.1903 ns |  2.2169 ns |  1.9652 ns |   285.8758 ns |   1.01 |    0.01 |      - |     - |     - |         - |
|    Hyperlinq_Foreach | .NET Core 5.0 | .NET Core 5.0 |     0 |  1000 | 1,538.3141 ns |  3.5314 ns |  3.1305 ns | 1,538.6482 ns |   5.45 |    0.04 |      - |     - |     - |         - |
|        Hyperlinq_For | .NET Core 5.0 | .NET Core 5.0 |     0 |  1000 |   549.9345 ns |  3.0972 ns |  2.7456 ns |   549.2929 ns |   1.95 |    0.02 |      - |     - |     - |         - |

## RangeSelect

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET 4.8      : .NET Framework 4.8 (4.8.4180.0), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT


```
|               Method |           Job |       Runtime | Start | Count |           Mean |      Error |     StdDev |         Median |    Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |-------------- |-------------- |------ |------ |---------------:|-----------:|-----------:|---------------:|---------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **0** |     **0** |      **0.2850 ns** |  **0.0107 ns** |  **0.0100 ns** |      **0.2881 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |     0 |     0 |     16.7971 ns |  0.1146 ns |  0.1072 ns |     16.7704 ns |    59.02 |    2.22 | 0.0268 |     - |     - |      56 B |
|                 Linq |      .NET 4.8 |      .NET 4.8 |     0 |     0 |     48.7747 ns |  0.2824 ns |  0.2642 ns |     48.7367 ns |   171.37 |    6.15 | 0.0535 |     - |     - |     112 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |     0 |     0 |     10.5819 ns |  0.0559 ns |  0.0466 ns |     10.5929 ns |    37.25 |    1.36 | 0.0229 |     - |     - |      48 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |     0 |     26.0768 ns |  0.1715 ns |  0.1604 ns |     26.0087 ns |    91.61 |    3.07 |      - |     - |     - |         - |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |     0 |     0 |     26.2868 ns |  0.1191 ns |  0.1114 ns |     26.2912 ns |    92.35 |    3.22 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |      .NET 4.8 |      .NET 4.8 |     0 |     0 |     43.7290 ns |  0.1958 ns |  0.1735 ns |     43.6861 ns |   153.80 |    5.71 |      - |     - |     - |         - |
|        Hyperlinq_For |      .NET 4.8 |      .NET 4.8 |     0 |     0 |     35.5818 ns |  0.1645 ns |  0.1538 ns |     35.5985 ns |   125.01 |    4.34 |      - |     - |     - |         - |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |     0 |      0.5212 ns |  0.0084 ns |  0.0074 ns |      0.5230 ns |     1.83 |    0.07 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |     0 |     22.7198 ns |  0.1431 ns |  0.1269 ns |     22.7095 ns |    79.91 |    3.02 | 0.0268 |     - |     - |      56 B |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |     0 |     22.0791 ns |  0.1429 ns |  0.1337 ns |     22.0995 ns |    77.58 |    2.95 |      - |     - |     - |         - |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     0 |     0 |     12.6733 ns |  0.1668 ns |  0.1560 ns |     12.6643 ns |    44.53 |    1.73 | 0.0229 |     - |     - |      48 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |     0 |     26.2032 ns |  0.3278 ns |  0.3066 ns |     26.0401 ns |    92.06 |    3.32 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |     0 |     0 |     26.2110 ns |  0.0668 ns |  0.0592 ns |     26.1997 ns |    92.19 |    3.41 |      - |     - |     - |         - |
|    Hyperlinq_Foreach | .NET Core 3.1 | .NET Core 3.1 |     0 |     0 |     38.0405 ns |  0.1583 ns |  0.1322 ns |     38.0120 ns |   133.93 |    5.18 |      - |     - |     - |         - |
|        Hyperlinq_For | .NET Core 3.1 | .NET Core 3.1 |     0 |     0 |     29.6739 ns |  0.1460 ns |  0.1295 ns |     29.6899 ns |   104.36 |    3.73 |      - |     - |     - |         - |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |     0 |      0.4736 ns |  0.0148 ns |  0.0131 ns |      0.4735 ns |     1.67 |    0.08 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |     0 |     22.7683 ns |  0.1022 ns |  0.0956 ns |     22.7946 ns |    79.99 |    2.83 | 0.0268 |     - |     - |      56 B |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |     0 |     23.1972 ns |  0.1426 ns |  0.1191 ns |     23.1677 ns |    81.67 |    3.10 |      - |     - |     - |         - |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     0 |     0 |     12.6744 ns |  0.1378 ns |  0.1151 ns |     12.6478 ns |    44.62 |    1.74 | 0.0229 |     - |     - |      48 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |     0 |     20.6760 ns |  0.0612 ns |  0.0543 ns |     20.6792 ns |    72.72 |    2.59 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |     0 |     0 |     21.2450 ns |  0.0911 ns |  0.0852 ns |     21.2271 ns |    74.64 |    2.65 |      - |     - |     - |         - |
|    Hyperlinq_Foreach | .NET Core 5.0 | .NET Core 5.0 |     0 |     0 |     32.5932 ns |  0.1978 ns |  0.1754 ns |     32.5718 ns |   114.63 |    4.01 |      - |     - |     - |         - |
|        Hyperlinq_For | .NET Core 5.0 | .NET Core 5.0 |     0 |     0 |     23.8376 ns |  0.0923 ns |  0.0818 ns |     23.8258 ns |    83.84 |    2.97 |      - |     - |     - |         - |
|                      |               |               |       |       |                |            |            |                |          |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **0** |     **1** |      **0.0529 ns** |  **0.0043 ns** |  **0.0034 ns** |      **0.0531 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |     0 |     1 |     21.3855 ns |  0.1110 ns |  0.0984 ns |     21.3662 ns |   405.65 |   26.02 | 0.0268 |     - |     - |      56 B |
|                 Linq |      .NET 4.8 |      .NET 4.8 |     0 |     1 |     60.4287 ns |  0.4788 ns |  0.4245 ns |     60.5746 ns | 1,145.26 |   74.18 | 0.0535 |     - |     - |     112 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |     0 |     1 |     12.7461 ns |  0.0491 ns |  0.0436 ns |     12.7339 ns |   241.85 |   15.20 | 0.0306 |     - |     - |      64 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |     1 |     28.0214 ns |  0.1019 ns |  0.0953 ns |     28.0320 ns |   531.99 |   32.90 |      - |     - |     - |         - |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |     0 |     1 |     27.3574 ns |  0.1501 ns |  0.1404 ns |     27.3382 ns |   519.52 |   33.32 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |      .NET 4.8 |      .NET 4.8 |     0 |     1 |     46.9566 ns |  0.2039 ns |  0.1808 ns |     46.9028 ns |   891.11 |   55.90 |      - |     - |     - |         - |
|        Hyperlinq_For |      .NET 4.8 |      .NET 4.8 |     0 |     1 |     38.3729 ns |  0.2027 ns |  0.1797 ns |     38.3150 ns |   728.26 |   44.89 |      - |     - |     - |         - |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |     1 |      0.2660 ns |  0.0129 ns |  0.0120 ns |      0.2666 ns |     5.04 |    0.37 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |     1 |     27.1613 ns |  0.2017 ns |  0.1887 ns |     27.2133 ns |   515.29 |   33.16 | 0.0268 |     - |     - |      56 B |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |     1 |     52.3649 ns |  0.6379 ns |  0.5967 ns |     52.2759 ns |   994.78 |   62.05 | 0.0421 |     - |     - |      88 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     0 |     1 |     14.3621 ns |  0.1030 ns |  0.0963 ns |     14.3407 ns |   272.23 |   17.99 | 0.0306 |     - |     - |      64 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |     1 |     27.8156 ns |  0.0881 ns |  0.0781 ns |     27.8128 ns |   527.90 |   33.28 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |     0 |     1 |     27.3729 ns |  0.0931 ns |  0.0825 ns |     27.3713 ns |   519.57 |   33.87 |      - |     - |     - |         - |
|    Hyperlinq_Foreach | .NET Core 3.1 | .NET Core 3.1 |     0 |     1 |     40.5471 ns |  0.1379 ns |  0.1222 ns |     40.5607 ns |   769.27 |   48.13 |      - |     - |     - |         - |
|        Hyperlinq_For | .NET Core 3.1 | .NET Core 3.1 |     0 |     1 |     32.6668 ns |  0.1631 ns |  0.1446 ns |     32.6952 ns |   619.56 |   38.85 |      - |     - |     - |         - |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |     1 |      0.0022 ns |  0.0041 ns |  0.0039 ns |      0.0000 ns |     0.03 |    0.06 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |     1 |     27.1916 ns |  0.2194 ns |  0.1713 ns |     27.2305 ns |   515.87 |   33.41 | 0.0268 |     - |     - |      56 B |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |     1 |     54.5232 ns |  0.4484 ns |  0.3975 ns |     54.5897 ns | 1,035.37 |   60.12 | 0.0421 |     - |     - |      88 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     0 |     1 |     13.9851 ns |  0.0889 ns |  0.0788 ns |     13.9913 ns |   265.19 |   17.22 | 0.0306 |     - |     - |      64 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |     1 |     22.9365 ns |  0.0672 ns |  0.0596 ns |     22.9209 ns |   435.15 |   27.32 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |     0 |     1 |     22.5713 ns |  0.1037 ns |  0.0919 ns |     22.5983 ns |   428.08 |   26.54 |      - |     - |     - |         - |
|    Hyperlinq_Foreach | .NET Core 5.0 | .NET Core 5.0 |     0 |     1 |     35.3498 ns |  0.1824 ns |  0.1617 ns |     35.3431 ns |   670.01 |   42.18 |      - |     - |     - |         - |
|        Hyperlinq_For | .NET Core 5.0 | .NET Core 5.0 |     0 |     1 |     26.7624 ns |  0.0648 ns |  0.0574 ns |     26.7545 ns |   507.89 |   31.86 |      - |     - |     - |         - |
|                      |               |               |       |       |                |            |            |                |          |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **0** |    **10** |      **3.3964 ns** |  **0.0267 ns** |  **0.0223 ns** |      **3.3969 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |     0 |    10 |     63.9298 ns |  0.3573 ns |  0.3167 ns |     63.8601 ns |    18.83 |    0.18 | 0.0267 |     - |     - |      56 B |
|                 Linq |      .NET 4.8 |      .NET 4.8 |     0 |    10 |    172.1708 ns |  0.9559 ns |  0.8474 ns |    172.0418 ns |    50.69 |    0.47 | 0.0534 |     - |     - |     112 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |     0 |    10 |     41.1224 ns |  0.2531 ns |  0.2244 ns |     41.0714 ns |    12.11 |    0.12 | 0.0612 |     - |     - |     128 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |    10 |     44.4998 ns |  0.1919 ns |  0.1701 ns |     44.4532 ns |    13.11 |    0.11 |      - |     - |     - |         - |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |     0 |    10 |     39.5953 ns |  0.1386 ns |  0.1297 ns |     39.5613 ns |    11.66 |    0.08 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |      .NET 4.8 |      .NET 4.8 |     0 |    10 |     78.1934 ns |  0.2276 ns |  0.1900 ns |     78.2129 ns |    23.02 |    0.16 |      - |     - |     - |         - |
|        Hyperlinq_For |      .NET 4.8 |      .NET 4.8 |     0 |    10 |     67.3111 ns |  0.2668 ns |  0.2495 ns |     67.4109 ns |    19.82 |    0.18 |      - |     - |     - |         - |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |    10 |      3.0103 ns |  0.0210 ns |  0.0175 ns |      3.0133 ns |     0.89 |    0.01 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |    10 |     66.3282 ns |  0.3438 ns |  0.3048 ns |     66.3018 ns |    19.53 |    0.17 | 0.0267 |     - |     - |      56 B |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |    10 |    111.0104 ns |  0.4382 ns |  0.3885 ns |    111.0933 ns |    32.68 |    0.22 | 0.0421 |     - |     - |      88 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     0 |    10 |     41.6867 ns |  0.3890 ns |  0.3639 ns |     41.7136 ns |    12.29 |    0.13 | 0.0612 |     - |     - |     128 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |    10 |     45.3492 ns |  0.2018 ns |  0.1888 ns |     45.3540 ns |    13.36 |    0.08 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |     0 |    10 |     39.3893 ns |  0.2415 ns |  0.2141 ns |     39.3344 ns |    11.59 |    0.08 |      - |     - |     - |         - |
|    Hyperlinq_Foreach | .NET Core 3.1 | .NET Core 3.1 |     0 |    10 |     71.6281 ns |  0.6301 ns |  0.5585 ns |     71.4963 ns |    21.10 |    0.20 |      - |     - |     - |         - |
|        Hyperlinq_For | .NET Core 3.1 | .NET Core 3.1 |     0 |    10 |     63.6441 ns |  0.3349 ns |  0.2968 ns |     63.7676 ns |    18.75 |    0.15 |      - |     - |     - |         - |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |    10 |      3.0097 ns |  0.0468 ns |  0.0391 ns |      3.0046 ns |     0.89 |    0.01 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |    10 |     66.6303 ns |  0.5181 ns |  0.4593 ns |     66.5141 ns |    19.62 |    0.23 | 0.0267 |     - |     - |      56 B |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |    10 |    117.4223 ns |  0.7180 ns |  0.6365 ns |    117.2452 ns |    34.55 |    0.27 | 0.0420 |     - |     - |      88 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     0 |    10 |     41.7538 ns |  0.1517 ns |  0.1345 ns |     41.7319 ns |    12.30 |    0.09 | 0.0612 |     - |     - |     128 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |    10 |     39.6914 ns |  0.2205 ns |  0.1955 ns |     39.6651 ns |    11.69 |    0.11 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |     0 |    10 |     35.5366 ns |  0.1493 ns |  0.1397 ns |     35.5482 ns |    10.47 |    0.08 |      - |     - |     - |         - |
|    Hyperlinq_Foreach | .NET Core 5.0 | .NET Core 5.0 |     0 |    10 |     60.3123 ns |  0.3243 ns |  0.3033 ns |     60.2995 ns |    17.75 |    0.12 |      - |     - |     - |         - |
|        Hyperlinq_For | .NET Core 5.0 | .NET Core 5.0 |     0 |    10 |     53.2452 ns |  0.2427 ns |  0.2271 ns |     53.3087 ns |    15.68 |    0.15 |      - |     - |     - |         - |
|                      |               |               |       |       |                |            |            |                |          |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **0** |  **1000** |    **334.7632 ns** |  **1.5194 ns** |  **1.4213 ns** |    **334.9252 ns** |     **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |     0 |  1000 |  4,620.0754 ns | 20.6586 ns | 17.2509 ns |  4,620.4208 ns |    13.80 |    0.10 | 0.0229 |     - |     - |      56 B |
|                 Linq |      .NET 4.8 |      .NET 4.8 |     0 |  1000 | 11,345.6853 ns | 48.1897 ns | 42.7189 ns | 11,348.1926 ns |    33.89 |    0.18 | 0.0458 |     - |     - |     112 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |     0 |  1000 |  3,239.4210 ns | 22.1484 ns | 19.6339 ns |  3,245.3093 ns |     9.68 |    0.08 | 3.8452 |     - |     - |    8082 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |  1000 |  2,705.9471 ns | 10.7428 ns |  8.9707 ns |  2,704.6402 ns |     8.08 |    0.05 |      - |     - |     - |         - |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |     0 |  1000 |  1,475.4485 ns |  3.8196 ns |  3.5728 ns |  1,475.0593 ns |     4.41 |    0.02 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |      .NET 4.8 |      .NET 4.8 |     0 |  1000 |  3,583.8154 ns | 19.8760 ns | 17.6196 ns |  3,586.2061 ns |    10.70 |    0.04 |      - |     - |     - |         - |
|        Hyperlinq_For |      .NET 4.8 |      .NET 4.8 |     0 |  1000 |  3,262.4478 ns | 20.2047 ns | 17.9110 ns |  3,258.8186 ns |     9.75 |    0.08 |      - |     - |     - |         - |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |  1000 |    335.9116 ns |  1.9930 ns |  1.8643 ns |    335.6498 ns |     1.00 |    0.01 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |  1000 |  4,328.6605 ns | 21.4552 ns | 20.0693 ns |  4,321.9372 ns |    12.93 |    0.09 | 0.0229 |     - |     - |      56 B |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |  1000 |  5,497.4956 ns | 25.5970 ns | 23.9434 ns |  5,500.3853 ns |    16.42 |    0.11 | 0.0381 |     - |     - |      88 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     0 |  1000 |  3,268.8378 ns | 18.4663 ns | 17.2734 ns |  3,273.4623 ns |     9.76 |    0.07 | 3.8452 |     - |     - |    8048 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |  1000 |  2,518.9221 ns | 12.8150 ns | 11.3602 ns |  2,518.7614 ns |     7.52 |    0.06 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |     0 |  1000 |  1,475.3559 ns |  4.8577 ns |  4.5439 ns |  1,474.8590 ns |     4.41 |    0.02 |      - |     - |     - |         - |
|    Hyperlinq_Foreach | .NET Core 3.1 | .NET Core 3.1 |     0 |  1000 |  2,737.7332 ns | 13.1873 ns | 11.6902 ns |  2,738.7976 ns |     8.18 |    0.05 |      - |     - |     - |         - |
|        Hyperlinq_For | .NET Core 3.1 | .NET Core 3.1 |     0 |  1000 |  3,781.6407 ns | 16.9145 ns | 14.9942 ns |  3,780.3127 ns |    11.30 |    0.07 |      - |     - |     - |         - |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |  1000 |    326.0376 ns |  1.8266 ns |  1.6192 ns |    326.5019 ns |     0.97 |    0.01 |      - |     - |     - |         - |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |  1000 |  4,346.6095 ns | 23.2079 ns | 21.7087 ns |  4,348.0659 ns |    12.98 |    0.09 | 0.0229 |     - |     - |      56 B |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |  1000 |  5,205.5910 ns | 38.3515 ns | 35.8740 ns |  5,203.4668 ns |    15.55 |    0.11 | 0.0381 |     - |     - |      88 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     0 |  1000 |  3,532.7451 ns | 18.9975 ns | 16.8408 ns |  3,533.6433 ns |    10.55 |    0.06 | 3.8452 |     - |     - |    8048 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |  1000 |  2,176.2157 ns |  7.5018 ns |  6.2644 ns |  2,175.6451 ns |     6.50 |    0.04 |      - |     - |     - |         - |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |     0 |  1000 |  1,484.2795 ns |  5.8000 ns |  5.4253 ns |  1,484.3840 ns |     4.43 |    0.02 |      - |     - |     - |         - |
|    Hyperlinq_Foreach | .NET Core 5.0 | .NET Core 5.0 |     0 |  1000 |  3,270.2641 ns | 16.1819 ns | 14.3449 ns |  3,270.3403 ns |     9.77 |    0.06 |      - |     - |     - |         - |
|        Hyperlinq_For | .NET Core 5.0 | .NET Core 5.0 |     0 |  1000 |  3,258.9470 ns | 13.8343 ns | 12.2638 ns |  3,258.4995 ns |     9.73 |    0.06 |      - |     - |     - |         - |

## RangeSelectToArray

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET 4.8      : .NET Framework 4.8 (4.8.4180.0), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT


```
|               Method |           Job |       Runtime | Start | Count |          Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |-------------- |-------------- |------ |------ |--------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **0** |     **0** |      **2.716 ns** |  **0.0346 ns** |  **0.0307 ns** |  **1.00** |    **0.00** | **0.0115** |     **-** |     **-** |      **24 B** |
|                 Linq |      .NET 4.8 |      .NET 4.8 |     0 |     0 |     72.450 ns |  0.4616 ns |  0.4092 ns | 26.68 |    0.32 | 0.0650 |     - |     - |     136 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |     0 |     0 |      8.841 ns |  0.0576 ns |  0.0539 ns |  3.26 |    0.03 | 0.0229 |     - |     - |      48 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |     0 |     53.838 ns |  0.2759 ns |  0.2304 ns | 19.79 |    0.23 | 0.0459 |     - |     - |      96 B |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |     0 |     0 |     40.866 ns |  0.1758 ns |  0.1644 ns | 15.04 |    0.21 | 0.0459 |     - |     - |      96 B |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |     0 |     0 |     41.929 ns |  0.2015 ns |  0.1573 ns | 15.40 |    0.14 | 0.0114 |     - |     - |      24 B |
|       Hyperlinq_Pool |      .NET 4.8 |      .NET 4.8 |     0 |     0 |            NA |         NA |         NA |     ? |       ? |      - |     - |     - |         - |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |     0 |      3.245 ns |  0.0401 ns |  0.0356 ns |  1.19 |    0.02 | 0.0115 |     - |     - |      24 B |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |     0 |     19.332 ns |  0.1395 ns |  0.1236 ns |  7.12 |    0.11 |      - |     - |     - |         - |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     0 |     0 |     10.222 ns |  0.0504 ns |  0.0447 ns |  3.76 |    0.04 | 0.0229 |     - |     - |      48 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |     0 |     37.200 ns |  0.1652 ns |  0.1546 ns | 13.70 |    0.18 | 0.0306 |     - |     - |      64 B |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |     0 |     0 |     29.048 ns |  0.1504 ns |  0.1407 ns | 10.69 |    0.13 | 0.0306 |     - |     - |      64 B |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |     0 |     0 |     36.963 ns |  0.1779 ns |  0.1577 ns | 13.61 |    0.17 | 0.0114 |     - |     - |      24 B |
|       Hyperlinq_Pool | .NET Core 3.1 | .NET Core 3.1 |     0 |     0 |            NA |         NA |         NA |     ? |       ? |      - |     - |     - |         - |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |     0 |      3.218 ns |  0.0586 ns |  0.0548 ns |  1.19 |    0.02 | 0.0115 |     - |     - |      24 B |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |     0 |     21.307 ns |  0.1352 ns |  0.1265 ns |  7.84 |    0.12 |      - |     - |     - |         - |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     0 |     0 |      9.319 ns |  0.0825 ns |  0.0731 ns |  3.43 |    0.04 | 0.0229 |     - |     - |      48 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |     0 |     31.162 ns |  0.1776 ns |  0.1575 ns | 11.47 |    0.14 | 0.0306 |     - |     - |      64 B |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |     0 |     0 |     27.449 ns |  0.1267 ns |  0.1123 ns | 10.11 |    0.14 | 0.0306 |     - |     - |      64 B |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |     0 |     0 |     31.925 ns |  0.1647 ns |  0.1376 ns | 11.74 |    0.11 | 0.0114 |     - |     - |      24 B |
|       Hyperlinq_Pool | .NET Core 5.0 | .NET Core 5.0 |     0 |     0 |            NA |         NA |         NA |     ? |       ? |      - |     - |     - |         - |
|                      |               |               |       |       |               |            |            |       |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **0** |     **1** |      **3.207 ns** |  **0.0309 ns** |  **0.0274 ns** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **32 B** |
|                 Linq |      .NET 4.8 |      .NET 4.8 |     0 |     1 |     99.854 ns |  0.5039 ns |  0.4208 ns | 31.17 |    0.29 | 0.0880 |     - |     - |     185 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |     0 |     1 |     11.726 ns |  0.1452 ns |  0.1359 ns |  3.66 |    0.04 | 0.0306 |     - |     - |      64 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |     1 |     69.710 ns |  0.5982 ns |  0.5303 ns | 21.74 |    0.28 | 0.0688 |     - |     - |     144 B |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |     0 |     1 |     54.529 ns |  0.3501 ns |  0.3104 ns | 17.00 |    0.20 | 0.0688 |     - |     - |     144 B |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |     0 |     1 |     44.235 ns |  0.3361 ns |  0.2980 ns | 13.79 |    0.15 | 0.0153 |     - |     - |      32 B |
|       Hyperlinq_Pool |      .NET 4.8 |      .NET 4.8 |     0 |     1 |    132.374 ns |  1.7295 ns |  1.6178 ns | 41.32 |    0.72 | 0.0267 |     - |     - |      56 B |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |     1 |      3.790 ns |  0.0523 ns |  0.0463 ns |  1.18 |    0.02 | 0.0153 |     - |     - |      32 B |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |     1 |     43.986 ns |  0.3743 ns |  0.3501 ns | 13.72 |    0.22 | 0.0573 |     - |     - |     120 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     0 |     1 |     12.141 ns |  0.1104 ns |  0.0979 ns |  3.79 |    0.05 | 0.0306 |     - |     - |      64 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |     1 |     61.853 ns |  0.4708 ns |  0.4173 ns | 19.29 |    0.23 | 0.0648 |     - |     - |     136 B |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |     0 |     1 |     52.583 ns |  0.2453 ns |  0.2174 ns | 16.40 |    0.14 | 0.0650 |     - |     - |     136 B |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |     0 |     1 |     39.145 ns |  0.1290 ns |  0.1206 ns | 12.21 |    0.11 | 0.0152 |     - |     - |      32 B |
|       Hyperlinq_Pool | .NET Core 3.1 | .NET Core 3.1 |     0 |     1 |     95.620 ns |  1.0116 ns |  0.8447 ns | 29.84 |    0.26 | 0.0267 |     - |     - |      56 B |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |     1 |      3.720 ns |  0.0376 ns |  0.0334 ns |  1.16 |    0.02 | 0.0153 |     - |     - |      32 B |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |     1 |     47.519 ns |  0.3054 ns |  0.2707 ns | 14.82 |    0.15 | 0.0573 |     - |     - |     120 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     0 |     1 |     12.574 ns |  0.1218 ns |  0.1139 ns |  3.92 |    0.05 | 0.0305 |     - |     - |      64 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |     1 |     52.484 ns |  0.2648 ns |  0.2211 ns | 16.38 |    0.14 | 0.0650 |     - |     - |     136 B |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |     0 |     1 |     47.492 ns |  0.3754 ns |  0.3328 ns | 14.81 |    0.14 | 0.0649 |     - |     - |     136 B |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |     0 |     1 |     34.576 ns |  0.1560 ns |  0.1383 ns | 10.78 |    0.10 | 0.0152 |     - |     - |      32 B |
|       Hyperlinq_Pool | .NET Core 5.0 | .NET Core 5.0 |     0 |     1 |     89.428 ns |  0.5920 ns |  0.5248 ns | 27.89 |    0.36 | 0.0267 |     - |     - |      56 B |
|                      |               |               |       |       |               |            |            |       |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **0** |    **10** |     **10.787 ns** |  **0.1194 ns** |  **0.0997 ns** |  **1.00** |    **0.00** | **0.0306** |     **-** |     **-** |      **64 B** |
|                 Linq |      .NET 4.8 |      .NET 4.8 |     0 |    10 |    244.224 ns |  1.8259 ns |  1.6186 ns | 22.65 |    0.29 | 0.1721 |     - |     - |     361 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |     0 |    10 |     36.054 ns |  0.2605 ns |  0.2309 ns |  3.34 |    0.03 | 0.0612 |     - |     - |     128 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |    10 |    155.888 ns |  0.5967 ns |  0.4983 ns | 14.45 |    0.15 | 0.1528 |     - |     - |     321 B |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |     0 |    10 |    123.763 ns |  0.9401 ns |  0.7850 ns | 11.47 |    0.13 | 0.1528 |     - |     - |     321 B |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |     0 |    10 |     61.112 ns |  0.3574 ns |  0.3168 ns |  5.66 |    0.06 | 0.0305 |     - |     - |      64 B |
|       Hyperlinq_Pool |      .NET 4.8 |      .NET 4.8 |     0 |    10 |    153.257 ns |  0.9601 ns |  0.8981 ns | 14.21 |    0.15 | 0.0267 |     - |     - |      56 B |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |    10 |     10.949 ns |  0.1013 ns |  0.0846 ns |  1.02 |    0.01 | 0.0306 |     - |     - |      64 B |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |    10 |     60.087 ns |  1.2507 ns |  1.4403 ns |  5.63 |    0.12 | 0.0726 |     - |     - |     152 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     0 |    10 |     41.606 ns |  1.4038 ns |  4.1392 ns |  3.92 |    0.33 | 0.0612 |     - |     - |     128 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |    10 |    136.655 ns |  1.0462 ns |  0.9275 ns | 12.66 |    0.11 | 0.1490 |     - |     - |     312 B |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |     0 |    10 |    113.581 ns |  0.8235 ns |  0.7703 ns | 10.54 |    0.13 | 0.1491 |     - |     - |     312 B |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |     0 |    10 |     58.603 ns |  0.4684 ns |  0.4153 ns |  5.43 |    0.06 | 0.0305 |     - |     - |      64 B |
|       Hyperlinq_Pool | .NET Core 3.1 | .NET Core 3.1 |     0 |    10 |    113.611 ns |  0.5340 ns |  0.4733 ns | 10.53 |    0.12 | 0.0267 |     - |     - |      56 B |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |    10 |     10.096 ns |  0.0933 ns |  0.0873 ns |  0.94 |    0.01 | 0.0305 |     - |     - |      64 B |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |    10 |     65.677 ns |  0.3858 ns |  0.3221 ns |  6.09 |    0.06 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     0 |    10 |     42.286 ns |  0.2947 ns |  0.2613 ns |  3.92 |    0.03 | 0.0612 |     - |     - |     128 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |    10 |    113.349 ns |  1.0693 ns |  1.0002 ns | 10.50 |    0.13 | 0.1490 |     - |     - |     312 B |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |     0 |    10 |     96.664 ns |  0.7302 ns |  0.6097 ns |  8.96 |    0.10 | 0.1490 |     - |     - |     312 B |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |     0 |    10 |     48.637 ns |  0.4097 ns |  0.3632 ns |  4.51 |    0.05 | 0.0305 |     - |     - |      64 B |
|       Hyperlinq_Pool | .NET Core 5.0 | .NET Core 5.0 |     0 |    10 |    106.528 ns |  0.8898 ns |  0.7888 ns |  9.88 |    0.13 | 0.0267 |     - |     - |      56 B |
|                      |               |               |       |       |               |            |            |       |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **0** |  **1000** |    **747.359 ns** |  **5.6846 ns** |  **5.3174 ns** |  **1.00** |    **0.00** | **1.9226** |     **-** |     **-** |    **4041 B** |
|                 Linq |      .NET 4.8 |      .NET 4.8 |     0 |  1000 | 12,588.961 ns | 64.6006 ns | 57.2667 ns | 16.84 |    0.14 | 5.9814 |     - |     - |   12567 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |     0 |  1000 |  2,736.781 ns | 12.5131 ns | 10.4490 ns |  3.66 |    0.03 | 3.8452 |     - |     - |    8082 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |  1000 |  4,953.069 ns | 22.5087 ns | 21.0547 ns |  6.63 |    0.07 | 5.9662 |     - |     - |   12536 B |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |     0 |  1000 |  3,703.375 ns | 16.0767 ns | 13.4248 ns |  4.96 |    0.04 | 5.9700 |     - |     - |   12536 B |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |     0 |  1000 |  2,172.812 ns | 21.4241 ns | 17.8901 ns |  2.91 |    0.03 | 1.9226 |     - |     - |    4041 B |
|       Hyperlinq_Pool |      .NET 4.8 |      .NET 4.8 |     0 |  1000 |  2,616.681 ns |  8.7209 ns |  7.2823 ns |  3.50 |    0.03 | 0.0267 |     - |     - |      56 B |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |  1000 |    754.534 ns |  6.4150 ns |  6.0006 ns |  1.01 |    0.01 | 1.9226 |     - |     - |    4024 B |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |  1000 |  1,893.496 ns | 20.6024 ns | 18.2635 ns |  2.53 |    0.02 | 1.9646 |     - |     - |    4112 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     0 |  1000 |  2,764.983 ns | 23.0494 ns | 20.4327 ns |  3.70 |    0.04 | 3.8452 |     - |     - |    8048 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |  1000 |  4,100.606 ns | 26.8162 ns | 23.7718 ns |  5.49 |    0.06 | 5.9586 |     - |     - |   12480 B |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |     0 |  1000 |  2,787.391 ns | 13.1712 ns | 11.6759 ns |  3.73 |    0.03 | 5.9586 |     - |     - |   12480 B |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |     0 |  1000 |  2,158.854 ns | 16.6493 ns | 14.7591 ns |  2.89 |    0.02 | 1.9226 |     - |     - |    4024 B |
|       Hyperlinq_Pool | .NET Core 3.1 | .NET Core 3.1 |     0 |  1000 |  1,994.161 ns | 12.6263 ns | 10.5436 ns |  2.67 |    0.03 | 0.0267 |     - |     - |      56 B |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |  1000 |    861.364 ns | 16.8220 ns | 16.5214 ns |  1.15 |    0.03 | 1.9226 |     - |     - |    4024 B |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |  1000 |  2,156.723 ns | 13.0589 ns | 10.9048 ns |  2.89 |    0.02 | 1.9646 |     - |     - |    4112 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     0 |  1000 |  3,007.203 ns | 16.0267 ns | 14.2072 ns |  4.02 |    0.04 | 3.8452 |     - |     - |    8048 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |  1000 |  3,795.249 ns | 23.3898 ns | 20.7344 ns |  5.08 |    0.04 | 5.9586 |     - |     - |   12480 B |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |     0 |  1000 |  2,772.059 ns | 15.2311 ns | 13.5020 ns |  3.71 |    0.04 | 5.9586 |     - |     - |   12480 B |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |     0 |  1000 |  2,137.778 ns | 10.2377 ns |  9.5763 ns |  2.86 |    0.02 | 1.9226 |     - |     - |    4024 B |
|       Hyperlinq_Pool | .NET Core 5.0 | .NET Core 5.0 |     0 |  1000 |  1,994.777 ns | 21.2681 ns | 18.8536 ns |  2.67 |    0.04 | 0.0267 |     - |     - |      56 B |

Benchmarks with issues:
  RangeSelectToArray.Hyperlinq_Pool: .NET 4.8(Runtime=.NET 4.8) [Start=0, Count=0]
  RangeSelectToArray.Hyperlinq_Pool: .NET Core 3.1(Runtime=.NET Core 3.1) [Start=0, Count=0]
  RangeSelectToArray.Hyperlinq_Pool: .NET Core 5.0(Runtime=.NET Core 5.0) [Start=0, Count=0]

## RangeSelectToList

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET 4.8      : .NET Framework 4.8 (4.8.4180.0), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT


```
|               Method |           Job |       Runtime | Start | Count |          Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |-------------- |-------------- |------ |------ |--------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **0** |     **0** |      **8.952 ns** |  **0.0998 ns** |  **0.0885 ns** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |     0 |     0 |     28.438 ns |  0.1422 ns |  0.1331 ns |  3.18 |    0.04 | 0.0459 |     - |     - |      96 B |
|                 Linq |      .NET 4.8 |      .NET 4.8 |     0 |     0 |     76.752 ns |  0.4542 ns |  0.3546 ns |  8.58 |    0.10 | 0.0726 |     - |     - |     152 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |     0 |     0 |     46.592 ns |  0.2964 ns |  0.2772 ns |  5.21 |    0.06 | 0.0421 |     - |     - |      88 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |     0 |     43.750 ns |  0.0917 ns |  0.0813 ns |  4.89 |    0.05 | 0.0344 |     - |     - |      72 B |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |     0 |     0 |     30.849 ns |  0.2765 ns |  0.2587 ns |  3.45 |    0.05 | 0.0344 |     - |     - |      72 B |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |     0 |     0 |     43.052 ns |  0.3357 ns |  0.3140 ns |  4.81 |    0.04 | 0.0191 |     - |     - |      40 B |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |     0 |      5.767 ns |  0.1512 ns |  0.1262 ns |  0.64 |    0.01 | 0.0153 |     - |     - |      32 B |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |     0 |     32.597 ns |  0.7090 ns |  0.8164 ns |  3.62 |    0.08 | 0.0421 |     - |     - |      88 B |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |     0 |     24.589 ns |  0.1441 ns |  0.1278 ns |  2.75 |    0.04 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     0 |     0 |     30.555 ns |  0.2466 ns |  0.2186 ns |  3.41 |    0.05 | 0.0382 |     - |     - |      80 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |     0 |     35.832 ns |  0.2177 ns |  0.2037 ns |  4.00 |    0.05 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |     0 |     0 |     27.816 ns |  0.1507 ns |  0.1410 ns |  3.11 |    0.03 | 0.0306 |     - |     - |      64 B |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |     0 |     0 |     33.905 ns |  0.2069 ns |  0.1834 ns |  3.79 |    0.04 | 0.0153 |     - |     - |      32 B |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |     0 |      6.015 ns |  0.0778 ns |  0.0650 ns |  0.67 |    0.01 | 0.0153 |     - |     - |      32 B |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |     0 |     29.265 ns |  0.1805 ns |  0.1600 ns |  3.27 |    0.05 | 0.0421 |     - |     - |      88 B |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |     0 |     28.133 ns |  0.2080 ns |  0.1844 ns |  3.14 |    0.03 | 0.0152 |     - |     - |      32 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     0 |     0 |     24.170 ns |  0.3253 ns |  0.2883 ns |  2.70 |    0.03 | 0.0382 |     - |     - |      80 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |     0 |     30.277 ns |  0.1810 ns |  0.1604 ns |  3.38 |    0.04 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |     0 |     0 |     26.278 ns |  0.1538 ns |  0.1363 ns |  2.94 |    0.03 | 0.0305 |     - |     - |      64 B |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |     0 |     0 |     28.981 ns |  0.2902 ns |  0.2423 ns |  3.24 |    0.05 | 0.0152 |     - |     - |      32 B |
|                      |               |               |       |       |               |            |            |       |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **0** |     **1** |     **20.946 ns** |  **0.1200 ns** |  **0.1064 ns** |  **1.00** |    **0.00** | **0.0382** |     **-** |     **-** |      **80 B** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |     0 |     1 |     43.773 ns |  0.1795 ns |  0.1499 ns |  2.09 |    0.01 | 0.0650 |     - |     - |     136 B |
|                 Linq |      .NET 4.8 |      .NET 4.8 |     0 |     1 |     98.325 ns |  0.9416 ns |  0.8347 ns |  4.69 |    0.04 | 0.0918 |     - |     - |     193 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |     0 |     1 |     63.401 ns |  0.5186 ns |  0.4598 ns |  3.03 |    0.03 | 0.0650 |     - |     - |     136 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |     1 |     56.078 ns |  0.4097 ns |  0.3421 ns |  2.68 |    0.02 | 0.0535 |     - |     - |     112 B |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |     0 |     1 |     41.751 ns |  0.2814 ns |  0.2495 ns |  1.99 |    0.02 | 0.0535 |     - |     - |     112 B |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |     0 |     1 |     62.822 ns |  0.4553 ns |  0.4259 ns |  3.00 |    0.02 | 0.0612 |     - |     - |     128 B |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |     1 |     16.899 ns |  0.1976 ns |  0.1751 ns |  0.81 |    0.01 | 0.0344 |     - |     - |      72 B |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |     1 |     47.778 ns |  1.0190 ns |  1.0464 ns |  2.29 |    0.05 | 0.0612 |     - |     - |     128 B |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |     1 |     49.241 ns |  0.2000 ns |  0.1670 ns |  2.35 |    0.02 | 0.0727 |     - |     - |     152 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     0 |     1 |     49.514 ns |  0.3440 ns |  0.3050 ns |  2.36 |    0.02 | 0.0612 |     - |     - |     128 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |     1 |     48.952 ns |  0.2985 ns |  0.2492 ns |  2.34 |    0.02 | 0.0497 |     - |     - |     104 B |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |     0 |     1 |     39.122 ns |  0.2258 ns |  0.2001 ns |  1.87 |    0.01 | 0.0497 |     - |     - |     104 B |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |     0 |     1 |     56.985 ns |  0.4483 ns |  0.3974 ns |  2.72 |    0.03 | 0.0572 |     - |     - |     120 B |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |     1 |     15.604 ns |  0.1360 ns |  0.1205 ns |  0.74 |    0.01 | 0.0344 |     - |     - |      72 B |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |     1 |     46.006 ns |  0.2566 ns |  0.2275 ns |  2.20 |    0.01 | 0.0611 |     - |     - |     128 B |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |     1 |     51.683 ns |  0.6052 ns |  0.4725 ns |  2.47 |    0.02 | 0.0726 |     - |     - |     152 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     0 |     1 |     39.365 ns |  0.2420 ns |  0.2145 ns |  1.88 |    0.01 | 0.0611 |     - |     - |     128 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |     1 |     42.944 ns |  0.2811 ns |  0.2347 ns |  2.05 |    0.02 | 0.0496 |     - |     - |     104 B |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |     0 |     1 |     37.786 ns |  0.3091 ns |  0.2891 ns |  1.80 |    0.01 | 0.0496 |     - |     - |     104 B |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |     0 |     1 |     49.202 ns |  0.2353 ns |  0.2086 ns |  2.35 |    0.01 | 0.0573 |     - |     - |     120 B |
|                      |               |               |       |       |               |            |            |       |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **0** |    **10** |     **87.662 ns** |  **0.6161 ns** |  **0.4810 ns** |  **1.00** |    **0.00** | **0.1070** |     **-** |     **-** |     **225 B** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |     0 |    10 |    154.001 ns |  1.1705 ns |  1.0376 ns |  1.76 |    0.02 | 0.1338 |     - |     - |     281 B |
|                 Linq |      .NET 4.8 |      .NET 4.8 |     0 |    10 |    290.529 ns |  2.6721 ns |  2.3688 ns |  3.31 |    0.03 | 0.1602 |     - |     - |     337 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |     0 |    10 |     89.775 ns |  0.4343 ns |  0.4063 ns |  1.02 |    0.01 | 0.1109 |     - |     - |     233 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |    10 |    141.207 ns |  1.1200 ns |  0.9929 ns |  1.61 |    0.02 | 0.1223 |     - |     - |     257 B |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |     0 |    10 |    111.849 ns |  0.7717 ns |  0.7219 ns |  1.28 |    0.01 | 0.1223 |     - |     - |     257 B |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |     0 |    10 |     85.161 ns |  0.2565 ns |  0.2399 ns |  0.97 |    0.00 | 0.0764 |     - |     - |     160 B |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |    10 |     77.437 ns |  0.4869 ns |  0.4555 ns |  0.88 |    0.01 | 0.1032 |     - |     - |     216 B |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |    10 |    139.447 ns |  0.7793 ns |  0.6908 ns |  1.59 |    0.02 | 0.1299 |     - |     - |     272 B |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |    10 |     73.041 ns |  0.7050 ns |  0.6594 ns |  0.83 |    0.01 | 0.0880 |     - |     - |     184 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     0 |    10 |     75.582 ns |  0.6006 ns |  0.4689 ns |  0.86 |    0.01 | 0.1069 |     - |     - |     224 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |    10 |    115.780 ns |  1.1098 ns |  1.0381 ns |  1.32 |    0.01 | 0.1185 |     - |     - |     248 B |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |     0 |    10 |     96.133 ns |  0.6441 ns |  0.5710 ns |  1.10 |    0.01 | 0.1185 |     - |     - |     248 B |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |     0 |    10 |     75.459 ns |  0.5571 ns |  0.4939 ns |  0.86 |    0.01 | 0.0726 |     - |     - |     152 B |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |    10 |     66.833 ns |  0.5908 ns |  0.5527 ns |  0.76 |    0.01 | 0.1031 |     - |     - |     216 B |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |    10 |    131.255 ns |  1.0192 ns |  0.9534 ns |  1.49 |    0.01 | 0.1297 |     - |     - |     272 B |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |    10 |     73.498 ns |  0.5306 ns |  0.4704 ns |  0.84 |    0.01 | 0.0877 |     - |     - |     184 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     0 |    10 |     65.645 ns |  0.4799 ns |  0.4489 ns |  0.75 |    0.01 | 0.1069 |     - |     - |     224 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |    10 |     98.754 ns |  0.7808 ns |  0.6921 ns |  1.13 |    0.01 | 0.1184 |     - |     - |     248 B |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |     0 |    10 |     85.302 ns |  0.8312 ns |  0.7368 ns |  0.97 |    0.01 | 0.1184 |     - |     - |     248 B |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |     0 |    10 |     69.306 ns |  0.5165 ns |  0.4313 ns |  0.79 |    0.01 | 0.0725 |     - |     - |     152 B |
|                      |               |               |       |       |               |            |            |       |         |        |       |       |           |
|              **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **0** |  **1000** |  **3,088.592 ns** | **22.5156 ns** | **19.9595 ns** |  **1.00** |    **0.00** | **4.0321** |     **-** |     **-** |    **8461 B** |
|          ForeachLoop |      .NET 4.8 |      .NET 4.8 |     0 |  1000 |  6,908.135 ns | 28.1313 ns | 24.9376 ns |  2.24 |    0.02 | 4.0512 |     - |     - |    8516 B |
|                 Linq |      .NET 4.8 |      .NET 4.8 |     0 |  1000 | 14,177.325 ns | 62.2110 ns | 55.1485 ns |  4.59 |    0.03 | 4.0741 |     - |     - |    8571 B |
|           LinqFaster |      .NET 4.8 |      .NET 4.8 |     0 |  1000 |  2,785.466 ns | 13.3732 ns | 11.8550 ns |  0.90 |    0.01 | 5.7907 |     - |     - |   12169 B |
|           StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |  1000 |  5,114.366 ns | 33.8565 ns | 28.2717 ns |  1.66 |    0.01 | 4.0436 |     - |     - |    8490 B |
| StructLinq_IFunction |      .NET 4.8 |      .NET 4.8 |     0 |  1000 |  3,439.726 ns | 14.0337 ns | 12.4406 ns |  1.11 |    0.01 | 4.0436 |     - |     - |    8490 B |
|            Hyperlinq |      .NET 4.8 |      .NET 4.8 |     0 |  1000 |  2,474.812 ns | 14.6582 ns | 12.9941 ns |  0.80 |    0.01 | 1.9684 |     - |     - |    4136 B |
|              ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |  1000 |  2,274.225 ns | 15.9850 ns | 14.1703 ns |  0.74 |    0.01 | 4.0207 |     - |     - |    8424 B |
|          ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |  1000 |  5,783.487 ns | 41.6278 ns | 36.9019 ns |  1.87 |    0.01 | 4.0436 |     - |     - |    8480 B |
|                 Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |  1000 |  2,767.781 ns | 15.5806 ns | 14.5741 ns |  0.90 |    0.01 | 1.9798 |     - |     - |    4144 B |
|           LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     0 |  1000 |  2,902.868 ns | 25.6059 ns | 22.6990 ns |  0.94 |    0.01 | 5.7793 |     - |     - |   12104 B |
|           StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |  1000 |  3,782.475 ns | 42.4461 ns | 37.6274 ns |  1.22 |    0.01 | 4.0359 |     - |     - |    8456 B |
| StructLinq_IFunction | .NET Core 3.1 | .NET Core 3.1 |     0 |  1000 |  2,487.449 ns | 10.1851 ns |  9.0289 ns |  0.81 |    0.01 | 4.0359 |     - |     - |    8456 B |
|            Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |     0 |  1000 |  2,199.401 ns | 13.1640 ns | 12.3136 ns |  0.71 |    0.01 | 1.9646 |     - |     - |    4112 B |
|              ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |  1000 |  2,269.480 ns | 21.4909 ns | 19.0511 ns |  0.73 |    0.01 | 4.0207 |     - |     - |    8424 B |
|          ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |  1000 |  5,720.719 ns | 35.4814 ns | 31.4533 ns |  1.85 |    0.02 | 4.0436 |     - |     - |    8480 B |
|                 Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |  1000 |  3,107.187 ns |  9.3946 ns |  7.3347 ns |  1.01 |    0.01 | 1.9798 |     - |     - |    4144 B |
|           LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     0 |  1000 |  2,759.495 ns | 18.8182 ns | 17.6026 ns |  0.89 |    0.01 | 5.7793 |     - |     - |   12104 B |
|           StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |  1000 |  3,485.645 ns | 23.1675 ns | 21.6709 ns |  1.13 |    0.01 | 4.0359 |     - |     - |    8456 B |
| StructLinq_IFunction | .NET Core 5.0 | .NET Core 5.0 |     0 |  1000 |  2,445.618 ns | 18.4595 ns | 17.2670 ns |  0.79 |    0.01 | 4.0359 |     - |     - |    8456 B |
|            Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |     0 |  1000 |  2,160.505 ns | 11.5823 ns |  9.6717 ns |  0.70 |    0.01 | 1.9646 |     - |     - |    4112 B |

## RangeToArray

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET 4.8      : .NET Framework 4.8 (4.8.4180.0), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT


```
|         Method |           Job |       Runtime | Start | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------- |-------------- |-------------- |------ |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|        **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **0** |     **0** |     **3.218 ns** |  **0.0313 ns** |  **0.0293 ns** |  **1.00** |    **0.00** | **0.0115** |     **-** |     **-** |      **24 B** |
|           Linq |      .NET 4.8 |      .NET 4.8 |     0 |     0 |    38.365 ns |  0.3102 ns |  0.2590 ns | 11.94 |    0.15 | 0.0344 |     - |     - |      72 B |
|     LinqFaster |      .NET 4.8 |      .NET 4.8 |     0 |     0 |     3.410 ns |  0.0738 ns |  0.0654 ns |  1.06 |    0.02 | 0.0115 |     - |     - |      24 B |
|     StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |     0 |    26.010 ns |  0.2047 ns |  0.1815 ns |  8.09 |    0.11 | 0.0421 |     - |     - |      88 B |
|      Hyperlinq |      .NET 4.8 |      .NET 4.8 |     0 |     0 |     7.723 ns |  0.0834 ns |  0.0780 ns |  2.40 |    0.03 | 0.0115 |     - |     - |      24 B |
| Hyperlinq_Pool |      .NET 4.8 |      .NET 4.8 |     0 |     0 |           NA |         NA |         NA |     ? |       ? |      - |     - |     - |         - |
|        ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |     0 |     3.272 ns |  0.0435 ns |  0.0386 ns |  1.02 |    0.01 | 0.0115 |     - |     - |      24 B |
|           Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |     0 |     5.780 ns |  0.0412 ns |  0.0365 ns |  1.80 |    0.02 |      - |     - |     - |         - |
|     LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     0 |     0 |     4.375 ns |  0.0668 ns |  0.0625 ns |  1.36 |    0.02 | 0.0115 |     - |     - |      24 B |
|     StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |     0 |    13.915 ns |  0.1161 ns |  0.1029 ns |  4.33 |    0.05 | 0.0268 |     - |     - |      56 B |
|      Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |     0 |     0 |     8.851 ns |  0.0683 ns |  0.0571 ns |  2.76 |    0.02 | 0.0115 |     - |     - |      24 B |
| Hyperlinq_Pool | .NET Core 3.1 | .NET Core 3.1 |     0 |     0 |           NA |         NA |         NA |     ? |       ? |      - |     - |     - |         - |
|        ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |     0 |     3.184 ns |  0.0285 ns |  0.0253 ns |  0.99 |    0.01 | 0.0115 |     - |     - |      24 B |
|           Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |     0 |     5.554 ns |  0.0663 ns |  0.0587 ns |  1.73 |    0.02 |      - |     - |     - |         - |
|     LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     0 |     0 |     4.272 ns |  0.0585 ns |  0.0519 ns |  1.33 |    0.02 | 0.0115 |     - |     - |      24 B |
|     StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |     0 |    13.865 ns |  0.1015 ns |  0.0949 ns |  4.31 |    0.05 | 0.0268 |     - |     - |      56 B |
|      Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |     0 |     0 |     9.154 ns |  0.0572 ns |  0.0478 ns |  2.85 |    0.03 | 0.0114 |     - |     - |      24 B |
| Hyperlinq_Pool | .NET Core 5.0 | .NET Core 5.0 |     0 |     0 |           NA |         NA |         NA |     ? |       ? |      - |     - |     - |         - |
|                |               |               |       |       |              |            |            |       |         |        |       |       |           |
|        **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **0** |     **1** |     **3.184 ns** |  **0.0355 ns** |  **0.0332 ns** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **32 B** |
|           Linq |      .NET 4.8 |      .NET 4.8 |     0 |     1 |    57.946 ns |  0.4529 ns |  0.3782 ns | 18.17 |    0.19 | 0.0573 |     - |     - |     120 B |
|     LinqFaster |      .NET 4.8 |      .NET 4.8 |     0 |     1 |     3.544 ns |  0.0647 ns |  0.0574 ns |  1.11 |    0.02 | 0.0153 |     - |     - |      32 B |
|     StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |     1 |    43.601 ns |  0.3144 ns |  0.2455 ns | 13.67 |    0.13 | 0.0650 |     - |     - |     136 B |
|      Hyperlinq |      .NET 4.8 |      .NET 4.8 |     0 |     1 |     8.094 ns |  0.0844 ns |  0.0748 ns |  2.54 |    0.04 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_Pool |      .NET 4.8 |      .NET 4.8 |     0 |     1 |   112.853 ns |  0.6390 ns |  0.5336 ns | 35.39 |    0.37 | 0.0267 |     - |     - |      56 B |
|        ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |     1 |     3.857 ns |  0.0341 ns |  0.0285 ns |  1.21 |    0.01 | 0.0153 |     - |     - |      32 B |
|           Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |     1 |    19.158 ns |  0.1959 ns |  0.1737 ns |  6.02 |    0.08 | 0.0344 |     - |     - |      72 B |
|     LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     0 |     1 |     4.392 ns |  0.0602 ns |  0.0563 ns |  1.38 |    0.02 | 0.0153 |     - |     - |      32 B |
|     StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |     1 |    40.019 ns |  0.1668 ns |  0.1479 ns | 12.57 |    0.15 | 0.0612 |     - |     - |     128 B |
|      Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |     0 |     1 |     9.567 ns |  0.0539 ns |  0.0478 ns |  3.00 |    0.03 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_Pool | .NET Core 3.1 | .NET Core 3.1 |     0 |     1 |    80.993 ns |  0.6006 ns |  0.5324 ns | 25.44 |    0.25 | 0.0267 |     - |     - |      56 B |
|        ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |     1 |     3.716 ns |  0.0500 ns |  0.0443 ns |  1.17 |    0.02 | 0.0153 |     - |     - |      32 B |
|           Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |     1 |    18.978 ns |  0.1500 ns |  0.1253 ns |  5.95 |    0.06 | 0.0344 |     - |     - |      72 B |
|     LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     0 |     1 |     4.255 ns |  0.0518 ns |  0.0459 ns |  1.34 |    0.02 | 0.0153 |     - |     - |      32 B |
|     StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |     1 |    34.884 ns |  0.2072 ns |  0.1836 ns | 10.96 |    0.12 | 0.0611 |     - |     - |     128 B |
|      Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |     0 |     1 |     9.820 ns |  0.0584 ns |  0.0488 ns |  3.08 |    0.03 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_Pool | .NET Core 5.0 | .NET Core 5.0 |     0 |     1 |    77.828 ns |  0.5272 ns |  0.4674 ns | 24.45 |    0.34 | 0.0267 |     - |     - |      56 B |
|                |               |               |       |       |              |            |            |       |         |        |       |       |           |
|        **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **0** |    **10** |     **8.619 ns** |  **0.0600 ns** |  **0.0501 ns** |  **1.00** |    **0.00** | **0.0306** |     **-** |     **-** |      **64 B** |
|           Linq |      .NET 4.8 |      .NET 4.8 |     0 |    10 |   146.519 ns |  0.9806 ns |  0.7656 ns | 17.01 |    0.13 | 0.1414 |     - |     - |     297 B |
|     LinqFaster |      .NET 4.8 |      .NET 4.8 |     0 |    10 |     9.291 ns |  0.0864 ns |  0.0766 ns |  1.08 |    0.01 | 0.0306 |     - |     - |      64 B |
|     StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |    10 |   113.459 ns |  0.7976 ns |  0.6227 ns | 13.17 |    0.13 | 0.1491 |     - |     - |     313 B |
|      Hyperlinq |      .NET 4.8 |      .NET 4.8 |     0 |    10 |    14.231 ns |  0.0849 ns |  0.0752 ns |  1.65 |    0.01 | 0.0306 |     - |     - |      64 B |
| Hyperlinq_Pool |      .NET 4.8 |      .NET 4.8 |     0 |    10 |   121.398 ns |  0.7929 ns |  0.6621 ns | 14.09 |    0.12 | 0.0267 |     - |     - |      56 B |
|        ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |    10 |    11.045 ns |  0.0749 ns |  0.0664 ns |  1.28 |    0.01 | 0.0306 |     - |     - |      64 B |
|           Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |    10 |    24.015 ns |  0.1623 ns |  0.1518 ns |  2.78 |    0.02 | 0.0497 |     - |     - |     104 B |
|     LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     0 |    10 |    11.482 ns |  0.0813 ns |  0.0679 ns |  1.33 |    0.01 | 0.0306 |     - |     - |      64 B |
|     StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |    10 |   103.333 ns |  0.7613 ns |  0.6748 ns | 11.99 |    0.10 | 0.1453 |     - |     - |     304 B |
|      Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |     0 |    10 |    14.839 ns |  0.0978 ns |  0.0914 ns |  1.72 |    0.01 | 0.0306 |     - |     - |      64 B |
| Hyperlinq_Pool | .NET Core 3.1 | .NET Core 3.1 |     0 |    10 |    90.030 ns |  0.4645 ns |  0.4118 ns | 10.45 |    0.06 | 0.0267 |     - |     - |      56 B |
|        ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |    10 |     9.223 ns |  0.0737 ns |  0.0689 ns |  1.07 |    0.01 | 0.0306 |     - |     - |      64 B |
|           Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |    10 |    24.742 ns |  0.2559 ns |  0.2393 ns |  2.87 |    0.03 | 0.0497 |     - |     - |     104 B |
|     LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     0 |    10 |     9.454 ns |  0.1319 ns |  0.1169 ns |  1.10 |    0.02 | 0.0306 |     - |     - |      64 B |
|     StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |    10 |    81.648 ns |  0.3594 ns |  0.3186 ns |  9.48 |    0.05 | 0.1453 |     - |     - |     304 B |
|      Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |     0 |    10 |    16.219 ns |  0.1227 ns |  0.1148 ns |  1.88 |    0.01 | 0.0306 |     - |     - |      64 B |
| Hyperlinq_Pool | .NET Core 5.0 | .NET Core 5.0 |     0 |    10 |    73.871 ns |  0.4539 ns |  0.3790 ns |  8.57 |    0.06 | 0.0267 |     - |     - |      56 B |
|                |               |               |       |       |              |            |            |       |         |        |       |       |           |
|        **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **0** |  **1000** |   **735.042 ns** |  **2.2122 ns** |  **1.9611 ns** |  **1.00** |    **0.00** | **1.9226** |     **-** |     **-** |    **4041 B** |
|           Linq |      .NET 4.8 |      .NET 4.8 |     0 |  1000 | 6,529.677 ns | 43.0223 ns | 38.1382 ns |  8.88 |    0.06 | 5.9509 |     - |     - |   12507 B |
|     LinqFaster |      .NET 4.8 |      .NET 4.8 |     0 |  1000 |   616.407 ns |  4.2229 ns |  3.7435 ns |  0.84 |    0.01 | 1.9226 |     - |     - |    4041 B |
|     StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |  1000 | 3,314.382 ns | 14.6329 ns | 12.9716 ns |  4.51 |    0.02 | 5.9586 |     - |     - |   12523 B |
|      Hyperlinq |      .NET 4.8 |      .NET 4.8 |     0 |  1000 |   681.679 ns |  4.3881 ns |  4.1047 ns |  0.93 |    0.01 | 1.9226 |     - |     - |    4041 B |
| Hyperlinq_Pool |      .NET 4.8 |      .NET 4.8 |     0 |  1000 |   947.390 ns | 11.3598 ns | 10.0701 ns |  1.29 |    0.02 | 0.0267 |     - |     - |      56 B |
|        ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |  1000 |   785.383 ns |  7.8584 ns |  6.9663 ns |  1.07 |    0.01 | 1.9226 |     - |     - |    4024 B |
|           Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |  1000 |   624.947 ns |  5.2915 ns |  4.9496 ns |  0.85 |    0.01 | 1.9417 |     - |     - |    4064 B |
|     LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     0 |  1000 |   619.175 ns |  6.5565 ns |  5.8122 ns |  0.84 |    0.01 | 1.9226 |     - |     - |    4024 B |
|     StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |  1000 | 2,675.111 ns | 23.6782 ns | 22.1486 ns |  3.64 |    0.03 | 5.9624 |     - |     - |   12472 B |
|      Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |     0 |  1000 |   685.717 ns |  5.9468 ns |  4.9658 ns |  0.93 |    0.01 | 1.9226 |     - |     - |    4024 B |
| Hyperlinq_Pool | .NET Core 3.1 | .NET Core 3.1 |     0 |  1000 |   628.483 ns | 11.8095 ns |  9.8614 ns |  0.85 |    0.01 | 0.0267 |     - |     - |      56 B |
|        ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |  1000 |   720.029 ns |  8.8493 ns |  8.2777 ns |  0.98 |    0.01 | 1.9226 |     - |     - |    4024 B |
|           Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |  1000 |   605.847 ns | 12.0015 ns | 11.2262 ns |  0.82 |    0.02 | 1.9417 |     - |     - |    4064 B |
|     LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     0 |  1000 |   598.792 ns |  9.1954 ns |  8.1515 ns |  0.81 |    0.01 | 1.9226 |     - |     - |    4024 B |
|     StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |  1000 | 2,367.614 ns | 15.8457 ns | 14.8221 ns |  3.22 |    0.02 | 5.9624 |     - |     - |   12472 B |
|      Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |     0 |  1000 |   715.297 ns |  7.0947 ns |  6.6364 ns |  0.97 |    0.01 | 1.9226 |     - |     - |    4024 B |
| Hyperlinq_Pool | .NET Core 5.0 | .NET Core 5.0 |     0 |  1000 |   594.293 ns |  3.5899 ns |  3.3580 ns |  0.81 |    0.01 | 0.0267 |     - |     - |      56 B |

Benchmarks with issues:
  RangeToArray.Hyperlinq_Pool: .NET 4.8(Runtime=.NET 4.8) [Start=0, Count=0]
  RangeToArray.Hyperlinq_Pool: .NET Core 3.1(Runtime=.NET Core 3.1) [Start=0, Count=0]
  RangeToArray.Hyperlinq_Pool: .NET Core 5.0(Runtime=.NET Core 5.0) [Start=0, Count=0]

## RangeToList

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET 4.8      : .NET Framework 4.8 (4.8.4180.0), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT


```
|      Method |           Job |       Runtime | Start | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |-------------- |-------------- |------ |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|     **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **0** |     **0** |     **8.614 ns** |  **0.0530 ns** |  **0.0496 ns** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
| ForeachLoop |      .NET 4.8 |      .NET 4.8 |     0 |     0 |    26.107 ns |  0.4233 ns |  0.3960 ns |  3.03 |    0.05 | 0.0459 |     - |     - |      96 B |
|        Linq |      .NET 4.8 |      .NET 4.8 |     0 |     0 |    33.116 ns |  0.2283 ns |  0.2024 ns |  3.84 |    0.04 | 0.0421 |     - |     - |      88 B |
|  LinqFaster |      .NET 4.8 |      .NET 4.8 |     0 |     0 |    39.073 ns |  0.4344 ns |  0.3627 ns |  4.54 |    0.05 | 0.0306 |     - |     - |      64 B |
|  StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |     0 |    15.621 ns |  0.0763 ns |  0.0713 ns |  1.81 |    0.01 | 0.0306 |     - |     - |      64 B |
|   Hyperlinq |      .NET 4.8 |      .NET 4.8 |     0 |     0 |    24.436 ns |  0.1913 ns |  0.1696 ns |  2.84 |    0.02 | 0.0344 |     - |     - |      72 B |
|     ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |     0 |     5.914 ns |  0.0448 ns |  0.0419 ns |  0.69 |    0.00 | 0.0153 |     - |     - |      32 B |
| ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |     0 |    30.733 ns |  0.5316 ns |  0.4972 ns |  3.57 |    0.07 | 0.0421 |     - |     - |      88 B |
|        Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |     0 |     9.809 ns |  0.1854 ns |  0.1644 ns |  1.14 |    0.02 | 0.0153 |     - |     - |      32 B |
|  LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     0 |     0 |    25.386 ns |  0.1260 ns |  0.1179 ns |  2.95 |    0.02 | 0.0268 |     - |     - |      56 B |
|  StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |     0 |    12.867 ns |  0.1030 ns |  0.0913 ns |  1.49 |    0.01 | 0.0267 |     - |     - |      56 B |
|   Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |     0 |     0 |    18.537 ns |  0.1204 ns |  0.1127 ns |  2.15 |    0.02 | 0.0306 |     - |     - |      64 B |
|     ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |     0 |     6.308 ns |  0.0592 ns |  0.0554 ns |  0.73 |    0.01 | 0.0153 |     - |     - |      32 B |
| ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |     0 |    30.155 ns |  0.1357 ns |  0.1203 ns |  3.50 |    0.02 | 0.0421 |     - |     - |      88 B |
|        Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |     0 |    10.827 ns |  0.0672 ns |  0.0629 ns |  1.26 |    0.01 | 0.0153 |     - |     - |      32 B |
|  LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     0 |     0 |    19.114 ns |  0.2285 ns |  0.2025 ns |  2.22 |    0.03 | 0.0267 |     - |     - |      56 B |
|  StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |     0 |    12.265 ns |  0.1827 ns |  0.1619 ns |  1.42 |    0.02 | 0.0267 |     - |     - |      56 B |
|   Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |     0 |     0 |    17.250 ns |  0.2835 ns |  0.2513 ns |  2.00 |    0.03 | 0.0305 |     - |     - |      64 B |
|             |               |               |       |       |              |            |            |       |         |        |       |       |           |
|     **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **0** |     **1** |    **20.277 ns** |  **0.2622 ns** |  **0.2453 ns** |  **1.00** |    **0.00** | **0.0382** |     **-** |     **-** |      **80 B** |
| ForeachLoop |      .NET 4.8 |      .NET 4.8 |     0 |     1 |    42.093 ns |  0.5016 ns |  0.4692 ns |  2.08 |    0.04 | 0.0650 |     - |     - |     136 B |
|        Linq |      .NET 4.8 |      .NET 4.8 |     0 |     1 |    54.169 ns |  0.2233 ns |  0.2089 ns |  2.67 |    0.03 | 0.0612 |     - |     - |     128 B |
|  LinqFaster |      .NET 4.8 |      .NET 4.8 |     0 |     1 |    53.347 ns |  0.6368 ns |  0.5645 ns |  2.63 |    0.05 | 0.0497 |     - |     - |     104 B |
|  StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |     1 |    28.384 ns |  0.4336 ns |  0.4056 ns |  1.40 |    0.03 | 0.0497 |     - |     - |     104 B |
|   Hyperlinq |      .NET 4.8 |      .NET 4.8 |     0 |     1 |    27.504 ns |  0.5511 ns |  0.5155 ns |  1.36 |    0.03 | 0.0497 |     - |     - |     104 B |
|     ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |     1 |    16.972 ns |  0.2840 ns |  0.2789 ns |  0.84 |    0.01 | 0.0344 |     - |     - |      72 B |
| ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |     1 |    46.243 ns |  0.5533 ns |  0.4620 ns |  2.28 |    0.04 | 0.0612 |     - |     - |     128 B |
|        Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |     1 |    26.224 ns |  0.1545 ns |  0.1290 ns |  1.29 |    0.02 | 0.0497 |     - |     - |     104 B |
|  LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     0 |     1 |    40.326 ns |  0.2903 ns |  0.2715 ns |  1.99 |    0.03 | 0.0458 |     - |     - |      96 B |
|  StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |     1 |    24.215 ns |  0.2816 ns |  0.2496 ns |  1.19 |    0.02 | 0.0459 |     - |     - |      96 B |
|   Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |     0 |     1 |    26.506 ns |  0.2475 ns |  0.2194 ns |  1.31 |    0.02 | 0.0458 |     - |     - |      96 B |
|     ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |     1 |    17.238 ns |  0.1016 ns |  0.0901 ns |  0.85 |    0.01 | 0.0344 |     - |     - |      72 B |
| ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |     1 |    45.775 ns |  0.2405 ns |  0.2250 ns |  2.26 |    0.02 | 0.0611 |     - |     - |     128 B |
|        Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |     1 |    27.407 ns |  0.2816 ns |  0.2634 ns |  1.35 |    0.02 | 0.0497 |     - |     - |     104 B |
|  LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     0 |     1 |    31.723 ns |  0.1588 ns |  0.1240 ns |  1.56 |    0.02 | 0.0458 |     - |     - |      96 B |
|  StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |     1 |    24.412 ns |  0.2671 ns |  0.2085 ns |  1.20 |    0.02 | 0.0459 |     - |     - |      96 B |
|   Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |     0 |     1 |    25.447 ns |  0.0706 ns |  0.0551 ns |  1.25 |    0.01 | 0.0459 |     - |     - |      96 B |
|             |               |               |       |       |              |            |            |       |         |        |       |       |           |
|     **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **0** |    **10** |    **87.684 ns** |  **0.4325 ns** |  **0.4045 ns** |  **1.00** |    **0.00** | **0.1070** |     **-** |     **-** |     **225 B** |
| ForeachLoop |      .NET 4.8 |      .NET 4.8 |     0 |    10 |   154.084 ns |  1.0450 ns |  0.9263 ns |  1.76 |    0.01 | 0.1338 |     - |     - |     281 B |
|        Linq |      .NET 4.8 |      .NET 4.8 |     0 |    10 |   171.769 ns |  1.4620 ns |  1.2960 ns |  1.96 |    0.02 | 0.1299 |     - |     - |     273 B |
|  LinqFaster |      .NET 4.8 |      .NET 4.8 |     0 |    10 |    64.487 ns |  0.4235 ns |  0.3754 ns |  0.74 |    0.00 | 0.0802 |     - |     - |     168 B |
|  StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |    10 |    96.664 ns |  0.5172 ns |  0.4585 ns |  1.10 |    0.01 | 0.1185 |     - |     - |     249 B |
|   Hyperlinq |      .NET 4.8 |      .NET 4.8 |     0 |    10 |    34.867 ns |  0.2382 ns |  0.2228 ns |  0.40 |    0.00 | 0.0650 |     - |     - |     136 B |
|     ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |    10 |    77.848 ns |  0.5808 ns |  0.5148 ns |  0.89 |    0.01 | 0.1032 |     - |     - |     216 B |
| ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |    10 |   143.049 ns |  1.4943 ns |  1.3247 ns |  1.63 |    0.01 | 0.1299 |     - |     - |     272 B |
|        Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |    10 |    42.588 ns |  0.3709 ns |  0.3097 ns |  0.49 |    0.00 | 0.0650 |     - |     - |     136 B |
|  LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     0 |    10 |    48.717 ns |  0.3226 ns |  0.3018 ns |  0.56 |    0.00 | 0.0764 |     - |     - |     160 B |
|  StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |    10 |    80.898 ns |  0.3435 ns |  0.3045 ns |  0.92 |    0.01 | 0.1147 |     - |     - |     240 B |
|   Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |     0 |    10 |    31.926 ns |  0.7080 ns |  1.1022 ns |  0.37 |    0.01 | 0.0612 |     - |     - |     128 B |
|     ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |    10 |    68.209 ns |  0.6782 ns |  0.6344 ns |  0.78 |    0.01 | 0.1031 |     - |     - |     216 B |
| ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |    10 |   129.737 ns |  0.8258 ns |  0.7725 ns |  1.48 |    0.01 | 0.1297 |     - |     - |     272 B |
|        Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |    10 |    43.361 ns |  0.2646 ns |  0.2345 ns |  0.49 |    0.00 | 0.0649 |     - |     - |     136 B |
|  LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     0 |    10 |    39.024 ns |  0.3412 ns |  0.3025 ns |  0.45 |    0.00 | 0.0764 |     - |     - |     160 B |
|  StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |    10 |    71.189 ns |  0.4090 ns |  0.3626 ns |  0.81 |    0.01 | 0.1146 |     - |     - |     240 B |
|   Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |     0 |    10 |    29.878 ns |  0.2014 ns |  0.1785 ns |  0.34 |    0.00 | 0.0611 |     - |     - |     128 B |
|             |               |               |       |       |              |            |            |       |         |        |       |       |           |
|     **ForLoop** |      **.NET 4.8** |      **.NET 4.8** |     **0** |  **1000** | **3,035.359 ns** | **16.8470 ns** | **15.7587 ns** |  **1.00** |    **0.00** | **4.0321** |     **-** |     **-** |    **8461 B** |
| ForeachLoop |      .NET 4.8 |      .NET 4.8 |     0 |  1000 | 6,929.697 ns | 43.9351 ns | 41.0969 ns |  2.28 |    0.02 | 4.0512 |     - |     - |    8516 B |
|        Linq |      .NET 4.8 |      .NET 4.8 |     0 |  1000 | 7,784.421 ns | 18.6184 ns | 15.5472 ns |  2.57 |    0.01 | 4.0436 |     - |     - |    8507 B |
|  LinqFaster |      .NET 4.8 |      .NET 4.8 |     0 |  1000 | 1,025.535 ns |  9.3048 ns |  7.7699 ns |  0.34 |    0.00 | 3.8605 |     - |     - |    8113 B |
|  StructLinq |      .NET 4.8 |      .NET 4.8 |     0 |  1000 | 3,030.915 ns | 15.7002 ns | 13.9178 ns |  1.00 |    0.00 | 4.0359 |     - |     - |    8482 B |
|   Hyperlinq |      .NET 4.8 |      .NET 4.8 |     0 |  1000 |   763.586 ns |  4.2593 ns |  3.7757 ns |  0.25 |    0.00 | 1.9569 |     - |     - |    4112 B |
|     ForLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |  1000 | 2,259.946 ns | 19.9420 ns | 18.6538 ns |  0.74 |    0.01 | 4.0207 |     - |     - |    8424 B |
| ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |     0 |  1000 | 5,811.158 ns | 25.7083 ns | 24.0476 ns |  1.91 |    0.02 | 4.0436 |     - |     - |    8480 B |
|        Linq | .NET Core 3.1 | .NET Core 3.1 |     0 |  1000 | 1,567.493 ns | 13.4611 ns | 12.5915 ns |  0.52 |    0.01 | 1.9569 |     - |     - |    4096 B |
|  LinqFaster | .NET Core 3.1 | .NET Core 3.1 |     0 |  1000 | 1,022.279 ns | 12.8670 ns | 11.4063 ns |  0.34 |    0.00 | 3.8605 |     - |     - |    8080 B |
|  StructLinq | .NET Core 3.1 | .NET Core 3.1 |     0 |  1000 | 2,187.615 ns | 14.7400 ns | 13.0666 ns |  0.72 |    0.01 | 4.0321 |     - |     - |    8448 B |
|   Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |     0 |  1000 |   692.456 ns |  6.9800 ns |  6.1876 ns |  0.23 |    0.00 | 1.9531 |     - |     - |    4088 B |
|     ForLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |  1000 | 2,199.875 ns | 19.4920 ns | 18.2328 ns |  0.72 |    0.01 | 4.0207 |     - |     - |    8424 B |
| ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |     0 |  1000 | 6,259.458 ns | 46.6910 ns | 43.6748 ns |  2.06 |    0.02 | 4.0436 |     - |     - |    8480 B |
|        Linq | .NET Core 5.0 | .NET Core 5.0 |     0 |  1000 | 1,569.824 ns | 13.3068 ns | 12.4472 ns |  0.52 |    0.00 | 1.9569 |     - |     - |    4096 B |
|  LinqFaster | .NET Core 5.0 | .NET Core 5.0 |     0 |  1000 | 1,000.850 ns | 10.7184 ns |  9.5016 ns |  0.33 |    0.00 | 3.8605 |     - |     - |    8080 B |
|  StructLinq | .NET Core 5.0 | .NET Core 5.0 |     0 |  1000 | 2,139.804 ns | 17.9245 ns | 16.7666 ns |  0.70 |    0.01 | 4.0321 |     - |     - |    8448 B |
|   Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |     0 |  1000 |   687.915 ns |  2.0121 ns |  1.8821 ns |  0.23 |    0.00 | 1.9522 |     - |     - |    4088 B |

