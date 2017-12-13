import json
import threading
import time
import datetime
from selenium import webdriver
from selenium.webdriver.common.keys import Keys



def load_config_file():
    with open('config.json') as data_file:
        return json.load(data_file)

def up_thread(urls, timeLoop, count, driver, upSelector):
    for i in range(count):
        print(f'up lan:{i+1}/{count}')
        for link in urls:
            driver.get(link + '/up')
            print(link + '  ----> xong')
        currentDateTime = datetime.datetime.now()
        nextTimeToUp = datetime.datetime.now() + datetime.timedelta(minutes=timeLoop)
        print(f'up tiep luc:{nextTimeToUp}')
        time.sleep(timeLoop * 60)
    driver.quit()

def up_nhattao(urls, timeLoop, count, driver, upSelector):
    for i in range(count):
        print(f'up lan:{i+1}/{count}')
        for link in urls:
            driver.get(link)
            up_element = driver.find_element_by_css_selector(upSelector)
            up_element.click()
            print(link + '  ----> xong')
        currentDateTime = datetime.datetime.now()
        nextTimeToUp = datetime.datetime.now() + datetime.timedelta(minutes=timeLoop)
        print(f'up tiep luc:{nextTimeToUp}')
        time.sleep(timeLoop * 60)
    driver.quit()

UP_METHOD = {"5giay":up_thread,"nhattao":up_nhattao}

def login(username, password, loginPage,submitLoginSelector, userSelector, passwordSelector):
    driver = webdriver.Chrome('chromedriver.exe')
    driver.get(loginPage)

    usernameBox = driver.find_element_by_css_selector(userSelector)
    passwordBox = driver.find_element_by_css_selector(passwordSelector)
    submitBox = driver.find_element_by_css_selector(submitLoginSelector)

    usernameBox.send_keys(username)
    passwordBox.send_keys(password)
    submitBox.submit()
    return driver
def main():
    data = load_config_file()
    accounts = data["accounts"]
    
    threads = []
    for item in accounts:
        urls = item["linkup"]
        username = item["username"]
        password = item["password"]
        upInEvery = item["upInEvery"]
        upTime = item["upTime"]
        loginPage = item["loginPage"]
        submitLoginSelector = item["submitLoginSelector"]
        userSelector = item["userSelector"]
        passwordSelector = item["passwordSelector"]
        up_selector = item["upSelector"]
        website = item["website"]
        driver = login(username,password,loginPage,submitLoginSelector,userSelector,passwordSelector)
        threads.append(threading.Thread(target=UP_METHOD[website], args=(urls, upInEvery, upTime, driver,up_selector)))
        threads[-1].start()
	
    for thread in threads:
	    thread.join()

if __name__ == '__main__':
    main()
