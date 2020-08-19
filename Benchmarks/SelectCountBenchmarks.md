## SelectCountBenchmarks

### References:
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta25](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta25)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                         Method |           Categories | Count |       Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |--------------------- |------ |-----------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                     Linq_Array |                Array |   100 | 252.673 ns | 1.6149 ns | 1.3485 ns |  1.00 | 0.0229 |     - |     - |      48 B |
|                Hyperlinq_Array |                Array |   100 |  11.222 ns | 0.0521 ns | 0.0461 ns |  0.04 |      - |     - |     - |         - |
|                 Hyperlinq_Span |                Array |   100 |   8.897 ns | 0.0651 ns | 0.0609 ns |  0.04 |      - |     - |     - |         - |
|               Hyperlinq_Memory |                Array |   100 |  10.265 ns | 0.0826 ns | 0.0773 ns |  0.04 |      - |     - |     - |         - |
|                                |                      |       |            |           |           |       |        |       |       |           |
|          Linq_Enumerable_Value |     Enumerable_Value |   100 | 802.193 ns | 3.9246 ns | 3.4790 ns |  1.00 | 0.0381 |     - |     - |      80 B |
|     Hyperlinq_Enumerable_Value |     Enumerable_Value |   100 | 173.726 ns | 1.0221 ns | 0.9560 ns |  0.22 |      - |     - |     - |         - |
|                                |                      |       |            |           |           |       |        |       |       |           |
|          Linq_Collection_Value |     Collection_Value |   100 | 817.434 ns | 5.7032 ns | 5.3348 ns |  1.00 | 0.0381 |     - |     - |      80 B |
|     Hyperlinq_Collection_Value |     Collection_Value |   100 |  10.672 ns | 0.0540 ns | 0.0451 ns |  0.01 |      - |     - |     - |         - |
|                                |                      |       |            |           |           |       |        |       |       |           |
|                Linq_List_Value |           List_Value |   100 | 444.979 ns | 1.5629 ns | 1.3855 ns |  1.00 | 0.0267 |     - |     - |      56 B |
|           Hyperlinq_List_Value |           List_Value |   100 |  11.797 ns | 0.1178 ns | 0.1102 ns |  0.03 |      - |     - |     - |         - |
|                                |                      |       |            |           |           |       |        |       |       |           |
|      Linq_Enumerable_Reference | Enumerable_Reference |   100 | 697.075 ns | 2.2150 ns | 2.0719 ns |  1.00 | 0.0458 |     - |     - |      96 B |
| Hyperlinq_Enumerable_Reference | Enumerable_Reference |   100 | 303.303 ns | 1.4322 ns | 1.1960 ns |  0.44 | 0.0191 |     - |     - |      40 B |
|                                |                      |       |            |           |           |       |        |       |       |           |
|      Linq_Collection_Reference | Collection_Reference |   100 | 601.257 ns | 2.2662 ns | 2.1198 ns | 1.000 | 0.0381 |     - |     - |      80 B |
| Hyperlinq_Collection_Reference | Collection_Reference |   100 |   5.844 ns | 0.0247 ns | 0.0206 ns | 0.010 |      - |     - |     - |         - |
|                                |                      |       |            |           |           |       |        |       |       |           |
|            Linq_List_Reference |       List_Reference |   100 | 393.617 ns | 2.3638 ns | 2.0954 ns |  1.00 | 0.0267 |     - |     - |      56 B |
|       Hyperlinq_List_Reference |       List_Reference |   100 |  11.753 ns | 0.1110 ns | 0.1039 ns |  0.03 |      - |     - |     - |         - |
