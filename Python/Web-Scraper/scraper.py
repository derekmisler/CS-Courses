import argparse
import re
from multiprocessing.pool import ThreadPool as Pool
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

def parse_args():
	parser = argparse.ArgumentParser(description='Show upcoming Orange Peel events.')
	# parser.add_argument('--sort', metavar='FIELD', choices=['date', 'price'], default='date', help='sort by the specified field. Options are date and price.')
	# parser.add_argument('--max', metavar='MAX', type=int, help='show the top MAX entries only.')
	parser.add_argument('--csv', action='store_true', default=False, help='output the data in CSV format.')
	parser.add_argument('--workers', type=int, default=8, help='number of workers to use, 8 by default.')
	return parser.parse_args()

def show_orangepeel_data(options):
	event_urls = get_event_urls()
	for event_url in event_urls:
		print get_orangepeel_data(event_url)
	# pool = Pool(options.workers)
	# event_urls = get_event_urls()
	# results = sorted(pool.map(get_orangepeel_data, get_event_urls))
	print len(results)
	max = options.max
	if max is None or max > len(results):
		max = len(results)
	if options.csv:
		print(u'"title","date", "time", "price"')
	else:
		print(u'')
	for i in range(max):
		if options.csv:
			print(u'"{0}","{1}",{2},{3},{4}'.format(results[i]['title'], ', '.join(results[i]['date']), results[i]['time'], results[i]['price']))
		else:
			print(u'{0:5d} {1:3d} {2:3d} {3} ({4})'.format(results[i]['date'], results[i]['time'], results[i]['price'], results[i]['title']))

show_orangepeel_data(parse_args())
