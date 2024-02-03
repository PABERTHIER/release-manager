using Newtonsoft.Json;

namespace ReleaseManager.Services;

public class ReleaseService: IReleaseService
{
    private readonly string _localStorageDirectory = "..\\ReleaseManager\\LocalStorage";

    public Release GetReleaseById(Guid id)
    {
        CheckPath();

        List<string?> names = Directory.GetFiles(_localStorageDirectory, "*.json").Select(Path.GetFileNameWithoutExtension).ToList();

        foreach (string? name in names)
        {
            using StreamReader file = File.OpenText(Path.Combine(_localStorageDirectory, $"{name}.json"));
            JsonSerializer serializer = new ();
            Release? release = serializer.Deserialize(file, typeof(Release)) as Release;

            if (id == release?.Id)
            {
                return release;
            }
        }

        Console.WriteLine("The release does not exist");
        throw new Exception();
    }

    public List<ReleaseName> GetReleasesName()
    {
        CheckPath();

        List<string?> names = Directory.GetFiles(_localStorageDirectory, "*.json").Select(Path.GetFileNameWithoutExtension).ToList();
        List<ReleaseName> releasesName = [];

        foreach (string? name in names)
        {
            using StreamReader file = File.OpenText(Path.Combine(_localStorageDirectory, $"{name}.json"));
            JsonSerializer serializer = new ();
            Release? release = serializer.Deserialize(file, typeof(Release)) as Release;
            releasesName.Add(new ReleaseName { Id = release?.Id, Name = release?.Name });
        }

        return releasesName;
    }

    public Release CreateRelease(Release release)
    {
        try
        {
            CheckPath();

            string filePath = Path.Combine(_localStorageDirectory, $"{release.Name}.json");

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            release.Id = Guid.NewGuid();
            release.Tasks = CreateTasks(release);

            string jsonSerializedObj = JsonConvert.SerializeObject(release);
            File.WriteAllText(filePath, jsonSerializedObj);
            return release;

        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
            return release;
        }
    }

    public ReleaseTaskInfo UpdateTask(ReleaseTaskInfo taskInfo)
    {
        Release release = GetReleaseById(taskInfo.ReleaseId);

        if (release?.Id != null)
        {
            try
            {
                ReleaseTask? taskToUpdate = release?.Tasks?.Where(x => x.Id == taskInfo?.Task?.Id).FirstOrDefault();

                if (taskToUpdate != null)
                {
                    taskToUpdate.Name = taskInfo.Task?.Name;
                    taskToUpdate.NbDaysBeforeRelease = taskInfo.Task?.NbDaysBeforeRelease;
                    taskToUpdate.IsDone = taskInfo.Task?.IsDone;
                }

                UpdateRelease(release!);

                return taskInfo;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return taskInfo;
            }
        }
        else
        {
            Console.WriteLine("The release does not exist");
            throw new Exception();
        }
    }

    private void UpdateRelease(Release release)
    {
        string filePath = Path.Combine(_localStorageDirectory, $"{release?.Name}.json");

        string jsonSerializedObj = JsonConvert.SerializeObject(release);
        File.WriteAllText(filePath, jsonSerializedObj);
    }

    private void CheckPath()
    {
        if (!Directory.Exists(_localStorageDirectory))
        {
            Directory.CreateDirectory(_localStorageDirectory);
        }
    }

    private static List<ReleaseTask> CreateTasks(Release release)
    {
        List<ReleaseTask> listTask =
        [
            new Task1(),
            new Task2(),
            new Task3(),
            new Task4(),
            new Task5(),
            new Task6(),
            new Task7(),
            new Task8(),
            new Task9(release.ReleaseDate),
            new Task10(release.ReleaseDate),
            new Task11(release.ReleaseDate),
            new Task12(),
            new Task13(),
            new Task14(),
            new Task15(),
            new Task16(),
            new Task17(),
            new Task18(),
            new Task19(),
            new Task20(),
            new Task21(),
            new Task22()
        ];

        return [.. listTask.OrderByDescending(x => x.NbDaysBeforeRelease)];
    }
}
