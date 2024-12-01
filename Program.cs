using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

const Int32 BufferSize = 128;
using (var fileStream = File.OpenRead("../../../input.txt"))
using (var streamReader = new StreamReader(fileStream, System.Text.Encoding.UTF8, true, BufferSize))
{
	String line;

	List<String> left = new List<String>();
	List<String> right = new List<String>();

	while ((line = streamReader.ReadLine()) != null)
	{
		String[] splitline = line.Split("   ");
		left.Add(splitline[0]);
		right.Add(splitline[1]);
	}
	left.Sort();
	right.Sort();
	List<int> dif = new();
	List<int> bal = left.Select(int.Parse).ToList();
	List<int> jobb = right.Select(int.Parse).ToList();

	for (int i = 0; i < left.Count; ++i)
	{
		dif.Add( Math.Abs(bal[i] - jobb[i]) );
	}

    Console.WriteLine(dif.Sum());

    //------  Második megoldás ✨ ------- 🐀         🐍⚔️🐍
    int outp = 0;
    for (int i = 0; i < bal.Count; ++i)
    {
        int balElem = bal[i];
        for(int j =0; j < jobb.Count; ++j)
        {
            int jobbElem = jobb[j];
            if(jobbElem == balElem)
            {
                outp += jobbElem;
            }
        }
        
    }
    Console.WriteLine(outp);
}