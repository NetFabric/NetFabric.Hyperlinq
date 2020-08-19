## WhereBenchmarks

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
|                              Method |                Categories | Count |       Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   449.2 ns |  1.33 ns |  1.18 ns |  1.00 | 0.0229 |     - |     - |      48 B |
|                    StructLinq_Array |                     Array |   100 |   316.8 ns |  1.72 ns |  1.53 ns |  0.71 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |   342.3 ns |  1.40 ns |  1.24 ns |  0.76 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |   338.3 ns |  3.47 ns |  3.25 ns |  0.75 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |   347.2 ns |  1.25 ns |  1.17 ns |  0.77 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,040.6 ns |  4.92 ns |  4.60 ns |  1.00 | 0.0381 |     - |     - |      80 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   994.9 ns |  5.62 ns |  5.25 ns |  0.96 | 0.0114 |     - |     - |      24 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   329.2 ns |  2.81 ns |  2.63 ns |  0.32 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,048.0 ns |  9.00 ns |  7.98 ns |  1.00 | 0.0381 |     - |     - |      80 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,007.3 ns |  4.53 ns |  4.24 ns |  0.96 | 0.0114 |     - |     - |      24 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   369.4 ns |  2.47 ns |  2.31 ns |  0.35 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,031.4 ns |  4.76 ns |  4.45 ns |  1.00 | 0.0381 |     - |     - |      80 B |
|               StructLinq_List_Value |                List_Value |   100 | 1,024.2 ns |  8.75 ns |  8.19 ns |  0.99 | 0.0114 |     - |     - |      24 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   626.7 ns |  1.54 ns |  1.37 ns |  0.61 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 5,991.2 ns | 24.67 ns | 23.08 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 5,193.2 ns | 41.61 ns | 36.89 ns |  0.87 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   899.2 ns |  3.72 ns |  3.48 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   786.5 ns |  3.25 ns |  3.04 ns |  0.87 | 0.0191 |     - |     - |      40 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   859.7 ns |  4.34 ns |  4.06 ns |  0.96 | 0.0191 |     - |     - |      40 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   845.2 ns |  3.16 ns |  2.80 ns |  1.00 | 0.0381 |     - |     - |      80 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   651.4 ns |  4.18 ns |  3.91 ns |  0.77 | 0.0114 |     - |     - |      24 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   796.1 ns |  2.84 ns |  2.65 ns |  0.94 | 0.0114 |     - |     - |      24 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   838.1 ns |  6.03 ns |  5.64 ns |  1.00 | 0.0381 |     - |     - |      80 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   728.8 ns |  2.17 ns |  1.92 ns |  0.87 | 0.0114 |     - |     - |      24 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   605.6 ns |  3.61 ns |  3.20 ns |  0.72 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 7,416.8 ns | 35.83 ns | 31.76 ns |  1.00 | 0.0305 |     - |     - |      64 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 7,479.9 ns | 29.97 ns | 28.04 ns |  1.01 |      - |     - |     - |         - |
