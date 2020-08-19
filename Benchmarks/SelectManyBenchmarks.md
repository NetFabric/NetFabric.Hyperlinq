## SelectManyBenchmarks

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
|                         Method |           Categories | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |--------------------- |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                     Linq_Array |                Array |   100 | 3.592 μs | 0.0205 μs | 0.0182 μs |  1.00 | 1.9569 |     - |     - |    4096 B |
|                Hyperlinq_Array |                Array |   100 | 1.340 μs | 0.0048 μs | 0.0045 μs |  0.37 |      - |     - |     - |         - |
|               Hyperlinq_Memory |                Array |   100 | 1.451 μs | 0.0082 μs | 0.0077 μs |  0.40 |      - |     - |     - |         - |
|                                |                      |       |          |           |           |       |        |       |       |           |
|          Linq_Enumerable_Value |     Enumerable_Value |   100 | 3.756 μs | 0.0146 μs | 0.0129 μs |  1.00 | 1.9531 |     - |     - |    4088 B |
|     Hyperlinq_Enumerable_Value |     Enumerable_Value |   100 | 1.364 μs | 0.0087 μs | 0.0082 μs |  0.36 |      - |     - |     - |         - |
|                                |                      |       |          |           |           |       |        |       |       |           |
|          Linq_Collection_Value |     Collection_Value |   100 | 3.975 μs | 0.0553 μs | 0.0490 μs |  1.00 | 1.9531 |     - |     - |    4088 B |
|     Hyperlinq_Collection_Value |     Collection_Value |   100 | 1.364 μs | 0.0081 μs | 0.0076 μs |  0.34 |      - |     - |     - |         - |
|                                |                      |       |          |           |           |       |        |       |       |           |
|                Linq_List_Value |           List_Value |   100 | 3.899 μs | 0.0168 μs | 0.0157 μs |  1.00 | 1.9531 |     - |     - |    4088 B |
|           Hyperlinq_List_Value |           List_Value |   100 | 1.359 μs | 0.0057 μs | 0.0051 μs |  0.35 |      - |     - |     - |         - |
|                                |                      |       |          |           |           |       |        |       |       |           |
|      Linq_Enumerable_Reference | Enumerable_Reference |   100 | 3.678 μs | 0.0269 μs | 0.0225 μs |  1.00 | 1.9608 |     - |     - |    4104 B |
| Hyperlinq_Enumerable_Reference | Enumerable_Reference |   100 | 1.600 μs | 0.0043 μs | 0.0038 μs |  0.43 | 0.0191 |     - |     - |      40 B |
|                                |                      |       |          |           |           |       |        |       |       |           |
|      Linq_Collection_Reference | Collection_Reference |   100 | 3.510 μs | 0.0156 μs | 0.0130 μs |  1.00 | 1.9531 |     - |     - |    4088 B |
| Hyperlinq_Collection_Reference | Collection_Reference |   100 | 1.555 μs | 0.0106 μs | 0.0099 μs |  0.44 | 0.0114 |     - |     - |      24 B |
|                                |                      |       |          |           |           |       |        |       |       |           |
|            Linq_List_Reference |       List_Reference |   100 | 3.711 μs | 0.0206 μs | 0.0193 μs |  1.00 | 1.9531 |     - |     - |    4088 B |
|       Hyperlinq_List_Reference |       List_Reference |   100 | 1.360 μs | 0.0052 μs | 0.0046 μs |  0.37 |      - |     - |     - |         - |
