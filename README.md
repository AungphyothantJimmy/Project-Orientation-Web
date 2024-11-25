# Project Orientation Website

## Overview
<p>The <strong>Project Orientation Website</strong> is a web-based platform designed to streamline the onboarding process for projects within an organization. It supports two user roles: <strong>Admins</strong> and <strong>Members</strong>, each with distinct functionalities to manage and participate in projects effectively.</p>

---

## Features

### Admin Features

#### <strong>Project Management</strong>
<ul>
  <li>Create and manage projects.</li>
  <li>Assign members to specific projects.</li>
</ul>

#### <strong>Project Details Management</strong>
<ul>
  <li>Add and edit project details, including:</li>
  <ul>
    <li>Orientation video.</li>
    <li>Project description.</li>
  </ul>
</ul>

#### <strong>Quiz Management</strong>
<ul>
  <li>Create quizzes for each project to assess new members.</li>
  <li>View quiz results for all members in each project.</li>
</ul>

---

### Member Features

#### <strong>Project Participation</strong>
<ul>
  <li>View project details, including orientation videos and descriptions.</li>
  <li>View the list of assigned project members.</li>
</ul>

#### <strong>Quizzes</strong>
<ul>
  <li>Take quizzes related to assigned projects.</li>
  <li>View personal quiz results after submission.</li>
</ul>

---

## User Roles

### <strong>1. Admin</strong>
<p>Responsible for project creation and management.</p>
<ul>
  <li>Can:</li>
  <ul>
    <li>Assign members to projects.</li>
    <li>Upload orientation materials (videos and descriptions).</li>
    <li>Create and manage project-specific quizzes.</li>
    <li>View and analyze quiz results for all members.</li>
  </ul>
</ul>

### <strong>2. Member</strong>
<p>Assigned to projects by an Admin.</p>
<ul>
  <li>Can:</li>
  <ul>
    <li>Access project details and orientation materials.</li>
    <li>View the list of project members.</li>
    <li>Take quizzes and view their results.</li>
  </ul>
</ul>

---

## Technologies Used
- **Frontend:** HTML, CSS, JavaScript
- **Backend:** ASP.NET MVC (C#)
- **Database:** SQL Server
- **ORM:** Microsoft.EntityFrameworkCore
- **Development Tools:** Visual Studio


---

## Installation & Setup

### <strong>Prerequisites</strong>
<ul>
  <li>Install <strong>Visual Studio</strong> with ASP.NET MVC and SQL Server support.</li>
  <li>Set up <strong>SQL Server</strong> for the database.</li>
</ul>

---

### <strong>Steps to Run the Project</strong>
<ol>
  <li>Clone the repository:
    <pre><code>git clone &lt;repository-url&gt;
cd project-orientation-website</code></pre>
  </li>
  <li>Open the solution file (<code>.sln</code>) in Visual Studio.</li>
  <li>Configure the database connection string in the <code>appsettings.json</code> file.</li>
  <li>Run the migrations to set up the database:
    <pre><code>Update-Database</code></pre>
  </li>
  <li>Build and run the application.</li>
</ol>
