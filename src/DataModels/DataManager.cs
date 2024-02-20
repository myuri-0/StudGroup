using BaseDataModels.Repositories;

namespace BaseDataModels;

public class DataManager(IStudentRep studentRep, ICourseRep courseRep)
{
    public IStudentRep StudentRep { get; } = studentRep;
    public ICourseRep CourseRep { get; } = courseRep;
};