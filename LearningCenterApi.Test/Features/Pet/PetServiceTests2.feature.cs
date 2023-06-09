﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace LearningCenterApi.Test.Features.Pet
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class PetServiceTests2Feature : object, Xunit.IClassFixture<PetServiceTests2Feature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "PetServiceTests2.feature"
#line hidden
        
        public PetServiceTests2Feature(PetServiceTests2Feature.FixtureData fixtureData, LearningCenterApi_Test_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Pet", "PetServiceTests2", "As a Developer\r\nI want to add new Pet through API\r\nIn order to make it available " +
                    "for applications.", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 5
 #line hidden
#line 6
  testRunner.Given("the Endpoint https://localhost:5013/api/v1/pet is available", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Add Tutorial")]
        [Xunit.TraitAttribute("FeatureTitle", "PetServiceTests2")]
        [Xunit.TraitAttribute("Description", "Add Tutorial")]
        [Xunit.TraitAttribute("Category", "Pet-adding")]
        public virtual void AddTutorial()
        {
            string[] tagsOfScenario = new string[] {
                    "Pet-adding"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add Tutorial", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 8
 this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 5
 this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Description",
                            "Castrado",
                            "User Id"});
                table6.AddRow(new string[] {
                            "Bobby",
                            "soy un perro",
                            "1",
                            "1"});
#line 9
  testRunner.When("a Post Request is sent", ((string)(null)), table6, "When ");
#line hidden
#line 12
  testRunner.Then("A Response is received with Status 200", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                            "Id",
                            "Name",
                            "Description",
                            "Castrado",
                            "User Id"});
                table7.AddRow(new string[] {
                            "1",
                            "Bobby",
                            "soy un perro",
                            "1",
                            "1"});
#line 13
  testRunner.And("a Tutorial Resource is included in Response Body", ((string)(null)), table7, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Database has an error to store")]
        [Xunit.TraitAttribute("FeatureTitle", "PetServiceTests2")]
        [Xunit.TraitAttribute("Description", "Database has an error to store")]
        [Xunit.TraitAttribute("Category", "tutorial-adding")]
        public virtual void DatabaseHasAnErrorToStore()
        {
            string[] tagsOfScenario = new string[] {
                    "tutorial-adding"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Database has an error to store", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 17
 this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 5
 this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Description",
                            "Castrado",
                            "User Id"});
                table8.AddRow(new string[] {
                            "Bobby",
                            "soy un perro",
                            "1",
                            "1"});
#line 18
  testRunner.Given("a Post Request is sent", ((string)(null)), table8, "Given ");
#line hidden
#line 21
  testRunner.When("is something wrong with the database", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 22
  testRunner.Then("A Response is received with Status 500", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 23
  testRunner.And("An Error Message is returned with value \"An error has ocurred to connect with the" +
                        " server\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                PetServiceTests2Feature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                PetServiceTests2Feature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
