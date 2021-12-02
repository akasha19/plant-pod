# Workflow for doing a task

## Setup
Create a branch for every task you do. Before creating a branch make sure you are on master branch and pull from the remote repository. The naming convention is to seperate words with underscores, eg.: 'create backend project' -> 'create_backend_project'. Create a branch using 'git checkout -b create_backend_project'.

Make sure you are on the correct branch before starting to work. You can do this by using 'git branch' or 'git status'.

## Work on the task
Remember to "commit often, push regularly". When commiting write a message that is short and descriptive in order to document your progress. After you have completed the task check that the application works as intended and the feature is implemented/the bug is fixed. Make sure that you have removed all comments, debug print statements, unnecessary newlines and format the code. When you are done don't forget to push all changes to the remote branch.

## Create a pull request
On github, go to "Pull Requests" > "New pull request". Select master as base branch and your task branch as compare. Below you can review the changes once more (this might be useful to have an overview and see if you missed something). It will also indicate if there are any merge conflicts (this happens because the master has changed in the meantime). If so, merge master into your own branch to resolve them. After reviewing the changes create the pull request and add a reviewer (usually Nika) and description if neccessary. Create the pull request and wait for review (comments). If you get comments, resolve them or ask (if you have a question). Don't forget to tell the reviewer they need to review your code (again). After the reviewer has approved your pull request it can be merged into master.