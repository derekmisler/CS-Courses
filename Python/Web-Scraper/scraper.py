import re
import requests
import bs4

root_url = 'http://theorangepeel.net'
index_url = root_url + '/events/'

def get_event_urls():
	response = requests.get(index_url)
	soup = bs4.BeautifulSoup(response.text)
	return [a.attrs.get('href') for a in soup.select('.event-details .article-header .h2 a')]

def get_orangepeel_data(event_url):
	orangepeel_data = {}
	response = requests.get(root_url + event_url)
	soup = bs4.BeautifulSoup(response.text)
	orangepeel_data['title'] = soup.select('.article-header .entry-title')[0].get_text()
	# orangepeel_data['subtitle'] = soup.select('.article-header .event-subtitle')[0].get_text()
	orangepeel_data['date'] = soup.select('.vitals-left .event-date-sub')[0].get_text()
	orangepeel_data['time'] = soup.select('.vitals-left .event-time')[0].get_text()
	orangepeel_data['price'] = soup.select('.vitals-left .ticket-price')[0].get_text()
	# orangepeel_data['tickets_url'] = soup.select('.vitals-right .event-status.onsale a')[0].get_text()
	# orangepeel_data['facebook_url'] = soup.select('.vitals-right .facebook-rsvp')[0].get_text()
	# orangepeel_data['description'] = soup.select('item-content')[0].get_text()
	return orangepeel_data

def show_orangepeel_data():
	event_urls = get_event_urls()
	for event_url in event_urls:
		print get_orangepeel_data(event_url)

show_orangepeel_data()
