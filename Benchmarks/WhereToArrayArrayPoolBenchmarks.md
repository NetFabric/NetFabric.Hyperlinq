## WhereToArrayArrayPoolBenchmarks

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
|                         Method |           Categories | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |--------------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|                     Linq_Array |                Array |   100 |   451.0 ns | 2.79 ns | 2.47 ns |  1.00 | 0.3443 |     - |     - |     720 B |
|                Hyperlinq_Array |                Array |   100 |   568.3 ns | 5.07 ns | 4.24 ns |  1.26 | 0.0267 |     - |     - |      56 B |
|               Hyperlinq_Memory |                Array |   100 |   536.8 ns | 3.92 ns | 3.06 ns |  1.19 | 0.0267 |     - |     - |      56 B |
|                                |                      |       |            |         |         |       |        |       |       |           |
|          Linq_Enumerable_Value |     Enumerable_Value |   100 | 1,081.5 ns | 7.06 ns | 6.26 ns |  1.00 | 0.3586 |     - |     - |     752 B |
|     Hyperlinq_Enumerable_Value |     Enumerable_Value |   100 |   561.9 ns | 2.97 ns | 2.78 ns |  0.52 | 0.0267 |     - |     - |      56 B |
|                                |                      |       |            |         |         |       |        |       |       |           |
|          Linq_Collection_Value |     Collection_Value |   100 | 1,100.4 ns | 7.13 ns | 6.67 ns |  1.00 | 0.3586 |     - |     - |     752 B |
|     Hyperlinq_Collection_Value |     Collection_Value |   100 |   588.1 ns | 3.68 ns | 3.44 ns |  0.53 | 0.0267 |     - |     - |      56 B |
|                                |                      |       |            |         |         |       |        |       |       |           |
|                Linq_List_Value |           List_Value |   100 | 1,098.2 ns | 8.84 ns | 8.27 ns |  1.00 | 0.3586 |     - |     - |     752 B |
|           Hyperlinq_List_Value |           List_Value |   100 |   829.3 ns | 7.21 ns | 6.39 ns |  0.76 | 0.0267 |     - |     - |      56 B |
|                                |                      |       |            |         |         |       |        |       |       |           |
|      Linq_Enumerable_Reference | Enumerable_Reference |   100 |   893.5 ns | 4.67 ns | 4.37 ns |  1.00 | 0.3672 |     - |     - |     768 B |
| Hyperlinq_Enumerable_Reference | Enumerable_Reference |   100 |   997.3 ns | 5.22 ns | 4.88 ns |  1.12 | 0.0458 |     - |     - |      96 B |
|                                |                      |       |            |         |         |       |        |       |       |           |
|      Linq_Collection_Reference | Collection_Reference |   100 |   837.3 ns | 3.09 ns | 2.74 ns |  1.00 | 0.3595 |     - |     - |     752 B |
| Hyperlinq_Collection_Reference | Collection_Reference |   100 |   936.4 ns | 5.06 ns | 4.73 ns |  1.12 | 0.0381 |     - |     - |      80 B |
|                                |                      |       |            |         |         |       |        |       |       |           |
|            Linq_List_Reference |       List_Reference |   100 |   836.1 ns | 4.72 ns | 4.42 ns |  1.00 | 0.3595 |     - |     - |     752 B |
|       Hyperlinq_List_Reference |       List_Reference |   100 |   852.5 ns | 5.34 ns | 4.46 ns |  1.02 | 0.0267 |     - |     - |      56 B |
