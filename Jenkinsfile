pipeline {
    agent any

    environment {
        DOCKERHUB_CREDENTIALS = 'dockerhub-creds'   // Jenkins credentials ID
        DOCKERHUB_USERNAME = 'harshavar28'
        BACKEND_IMAGE = 'harshavar28/prj5-backend'
        FRONTEND_IMAGE = 'harshavar28/prj5-frontnend'
    }

    stages {

        stage('Build Docker Images') {
            steps {
                script {
                    def tag = "latest"  // or use GIT_COMMIT for unique tagging

                    // Backend
                    sh """
                    docker build -t ${BACKEND_IMAGE}:${tag} -f BMSB/Dockerfile .
                    """

                    // Frontend
                    sh """
                    docker build -t ${FRONTEND_IMAGE}:${tag} -f BMSF/Dockerfile .
                    """
                }
            }
        }

        stage('Login to Docker Hub') {
            steps {
                script {
                    docker.withRegistry('', DOCKERHUB_CREDENTIALS) {
                        echo 'Logged in to Docker Hub'
                    }
                }
            }
        }

        stage('Push Images') {
            steps {
                script {
                    def tag = "latest"

                    sh "docker push ${BACKEND_IMAGE}:${tag}"
                    sh "docker push ${FRONTEND_IMAGE}:${tag}"
                }
            }
        }

    }

    post {
        always {
            echo 'Cleaning up...'
            sh 'docker image prune -f'
        }
    }
}
