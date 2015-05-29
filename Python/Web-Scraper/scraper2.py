from lxml import html
import requests

root_url = 'http://theorangepeel.net'
index_url = root_url + '/events/blind-maiden/'

page = requests.get(index_url)
tree = html.fromstring(page.text)

#This will create a list of event URLs:
event_title = tree.xpath('h1[@itemprop="headline"]/text()')
#This will create a list of dates:
event_date = tree.xpath('span[@class="event-date-sub"]/text()')

print tree
print event_title
print event_date
