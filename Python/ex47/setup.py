try:
    from setuptools import setup
except ImportError:
    from distutils.core import setup

config = {
    'description': 'Practice.',
    'author': 'Derek Misler',
    'url': 'derekmisler.com',
    'download_url': 'https://github.com/derekmisler/CS-Courses/Python/',
    'author_email': 'derekmisler@gmail.com',
    'version': '0.1',
    'install_requires': ['nose'],
    'packages': ['ex47'],
    'scripts': ['bin'],
    'name': 'Test game'
}

setup(**config)