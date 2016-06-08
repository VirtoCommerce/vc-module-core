import org.eclipse.jgit.transport.URIish
import org.jenkinsci.plugins.gitclient.GitClient

node {
	env.WORKSPACE = pwd()
	stage 'Checkout'
		checkout([$class: 'GitSCM', extensions: [[$class: 'PathRestriction', excludedRegions: 'CommonAssemblyInfo\\.cs', includedRegions: '']]])
		
	stage 'Build'
		bat "Nuget restore VirtoCommerce.CoreModule.sln"
		bat "\"${tool 'MSBuild 12.0'}\" VirtoCommerce.CoreModule.sln /p:Configuration=Debug /p:Platform=\"Any CPU\""
		
	if (env.BRANCH_NAME == 'master') {
				
		stage 'Publish'
			bat "powershell.exe -File \"${env.VC_RES}\\script\\version3.ps1\" -solutiondir \"${env.WORKSPACE}\""
	   		bat 'Nuget\\build.bat'
	   		
	} 
	
	def build = manager.build
	def workspace = build.getWorkspace()
	def listener = manager.listener
	def environment = build.getEnvironment(listener)

	final def project = build.getProject()
	final def gitScm = project.getScm()
	final GitClient gitClient = gitScm.createClient(listener, environment, build, workspace);

	final def gitTagName = "TAG_NAME"
	final def comment = "COMMENT"
	final def remoteURI = new URIish("origin")


	step([$class: 'GitHubCommitStatusSetter', statusResultSource: [$class: 'ConditionalStatusResultSource', results: []]])
}
