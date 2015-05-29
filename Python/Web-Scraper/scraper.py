import requests
import bs4

root_url = 'http://theorangepeel.net'
index_url = root_url + '/events/'

def get_event_urls():
	response = requests.get(index_url)
	soup = bs4.BeautifulSoup(response.text)
	return [a.attrs.get('href') for a in soup.select('div.event-details header.article-header h3.h2 a')]
	
print(get_event_urls())

def get_event_data(event_url):
	event_data = {}
	response = requests.get(root_url + event_url)
	soup = bs4.BeautifulSoup(response.text)
	event_data['title'] = 
	