﻿using NUnit.Framework;
using OrangeHRM.Data.Constants;
using OrangeHRM.Data;
using OrangeHRM.PageObjects;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Net.Commons;

namespace OrangeHRM.Tests.OrangeHRM.Admin.Job
{
    [AllureNUnit]
    [AllureSuite("Admin > Job > Job Titles")]
    public class JobTitleTests : BaseTest
    {
        public JobTitleTests() : base(TestSettings.HomePageUrl)
        {
        }

        [SetUp]
        public void SetUpForJobsTests()
        {
            GenericPages.UsersPage.NavigateToCategory(MainMenuCategories.Admin);
            GenericPages.AdminNavigationPage.NavigateToTab(AdminCategories.Job, AdminCategories.JobTitlesMenuItem);
        }

        [Test]
        [AllureEpic("Tests for job titles functionality")]
        [AllureName("Job Records that are found")]
        [AllureSeverity(SeverityLevel.normal)]
        public void CompareAmountOfAllRows()
        {
            var countedRows = GenericPages.JobTitlesPage.CountAllRows();
            var countedRowsWithText = $"({countedRows})";

            var allRecordsText = GenericPages.JobTitlesPage.GetRecordsFoundText();
            Assert.AreEqual(allRecordsText, countedRowsWithText + Common.RecordsFoundText);
        }

        [Test]
        [AllureEpic("Tests for job functionality")]
        [AllureName("Add new job title")]
        [AllureSeverity(SeverityLevel.critical)]
        public void AddNewJobTitle()
        {
            GenericPages.JobTitlesPage.ClickAddButton();
            GenericPages.AddJobTitlePage.EnterJobTitle(AddJobTitle.JobTitleText);
            GenericPages.AddJobTitlePage.EnterJobDescription(AddJobTitle.JobDescriptionText);
            GenericPages.AddJobTitlePage.ClickSaveButton();

            var actualJobTitleValues = new List<Object>();
            var actualJobDescriptionValues = new List<Object>();
            var size = GenericPages.JobTitlesPage.CountAllRows();

            for (var i = 0; i < size; i++)
            {
                actualJobTitleValues.Add(GenericPages.JobTitlesPage.GetRowsJobTitleText(i));
                actualJobDescriptionValues.Add(GenericPages.JobTitlesPage.GetRowsJobDescriptionText(i));
            }

            Assert.IsTrue(actualJobTitleValues.Contains(AddJobTitle.JobTitleText));
            Assert.IsTrue(actualJobDescriptionValues.Contains(AddJobTitle.JobDescriptionText));
        }

        [Test]
        [AllureEpic("Tests for job titles functionality")]
        [AllureName("Edit appropriate job title")]
        [AllureSeverity(SeverityLevel.critical)]
        public void EditJobTitle()
        {
            GenericPages.JobTitlesPage.ClickAddButton();
            GenericPages.AddJobTitlePage.EnterJobTitle(AddJobTitle.NewJobTitleText);
            GenericPages.AddJobTitlePage.EnterJobDescription(AddJobTitle.JobDescriptionText);
            GenericPages.AddJobTitlePage.ClickSaveButton();
            GenericPages.JobTitlesPage.EditAppropriateJob(AddJobTitle.NewJobTitleText);
            GenericPages.AddJobTitlePage.EnterJobTitle(AddJobTitle.EditedText);
            GenericPages.AddJobTitlePage.EnterJobDescription(AddJobTitle.EditedText);
            GenericPages.AddJobTitlePage.ClickSaveButton();

            var jobsTitlesAfterEditing = new List<Object>();
            var jobsDescriptionsAfterEditing = new List<Object>();
            var size = GenericPages.JobTitlesPage.CountAllRows();
            for (var i = 0; i < size; i++)
            {
                jobsTitlesAfterEditing.Add(GenericPages.JobTitlesPage.GetRowsJobTitleText(i));
                jobsDescriptionsAfterEditing.Add(GenericPages.JobTitlesPage.GetRowsJobDescriptionText(i));
            }

            //specially failed test. Should be AddJobTitle.NewJobTitleText instead of AddJobTitle.JobTitleText
            Assert.IsTrue(jobsTitlesAfterEditing.Contains(AddJobTitle.JobTitleText + AddJobTitle.EditedText));
            Assert.IsTrue(jobsDescriptionsAfterEditing.Contains(AddJobTitle.JobDescriptionText + AddJobTitle.EditedText));
        }

        [Test]
        [AllureEpic("Tests for job titles functionality")]
        [AllureName("Delete job title")]
        [AllureSeverity(SeverityLevel.critical)]
        public void DeleteJobTitle()
        {
            var countedRows = GenericPages.JobTitlesPage.CountAllRows();
            var deletedJob = GenericPages.JobTitlesPage.GetLastRawUsername();
            GenericPages.JobTitlesPage.DeleteLastElement();
            var countedRowsAfterDeletion = GenericPages.JobTitlesPage.CountAllRows();
            Assert.AreEqual(countedRows - 1, countedRowsAfterDeletion);

            var jobsRowsAfterDeletion = new List<Object>();
            for (var i = 0; i < countedRowsAfterDeletion; i++)
            {
                jobsRowsAfterDeletion.Add(GenericPages.JobTitlesPage.GetRowsJobTitleText(i));
            }

            Assert.IsFalse(jobsRowsAfterDeletion.Contains(deletedJob));
        }

        [Test]
        [AllureEpic("Tests for job titles functionality")]
        [AllureName("Sort jobs by job titles")]
        [AllureSeverity(SeverityLevel.normal)]
        //[Ignore("Ignored test")]
        public void SortJobs()
        {
            //check default sorting
            var jobsTitlesByDefault = new List<Object>();
            var jobsTitlesSorted = new List<Object>();

            var size = GenericPages.JobTitlesPage.CountAllRows();
            for (var i = 0; i < size; i++)
            {
                jobsTitlesByDefault.Add(GenericPages.JobTitlesPage.GetRowsJobTitleText(i));
                jobsTitlesSorted.Add(GenericPages.JobTitlesPage.GetRowsJobTitleText(i));
            }
            jobsTitlesSorted.Sort();

            Assert.AreEqual(jobsTitlesSorted, jobsTitlesByDefault);

            //check desc sorting
            GenericPages.JobTitlesPage.SortJobTitlesDesc();
            jobsTitlesSorted.Reverse();

            jobsTitlesByDefault.Clear();
            for (var i = 0; i < size; i++)
            {
                jobsTitlesByDefault.Add(GenericPages.JobTitlesPage.GetRowsJobTitleText(i));
            }

            Assert.AreEqual(jobsTitlesSorted, jobsTitlesByDefault);

            //check asc sorting
            GenericPages.JobTitlesPage.SortJobTitlesAsc();
            jobsTitlesSorted.Reverse();

            jobsTitlesByDefault.Clear();
            for (var i = 0; i < size; i++)
            {
                jobsTitlesByDefault.Add(GenericPages.JobTitlesPage.GetRowsJobTitleText(i));
            }

            Assert.AreEqual(jobsTitlesSorted, jobsTitlesByDefault);
        }
    }
}
